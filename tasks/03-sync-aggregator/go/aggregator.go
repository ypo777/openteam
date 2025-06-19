// Package aggregator – stub for Concurrent File Stats Processor.
package aggregator

import (
	"fmt"
	"bufio"
	"context"
	"os"
	"path/filepath"
	"strconv"
	"strings"
	"sync"
	"time"
)

// Result mirrors one JSON object in the final array.
type Result struct {
	Path   string `json:"path"`
	Lines  int    `json:"lines,omitempty"`
	Words  int    `json:"words,omitempty"`
	Status string `json:"status"` // "ok" or "timeout"
}

type workItem struct {
	index int
	path string
}

type indexedResult struct {
	index int
	result Result
}

// Aggregate must read filelistPath, spin up *workers* goroutines,
// apply a per‑file timeout, and return results in **input order**.
func Aggregate(filelistPath string, workers, timeout int) ([]Result, error) {
	paths, err := readFileList(filelistPath)
	if err != nil {
		return nil, err
	}

	baseDir := filepath.Dir(filelistPath)

	workChan := make(chan workItem, len(paths))
	resultChan := make(chan indexedResult, len(paths))

	var wg sync.WaitGroup
	for i := 0; i < workers; i++ {
		wg.Add(1)
		go worker(&wg, workChan, resultChan, timeout, baseDir)
	}

	for i, path := range paths {
		workChan <- workItem{index: i, path: path}
	}
	close(workChan)

	go func() {
		wg.Wait()
		close(resultChan)
	}()

	results := make([]Result, len(paths))
	for indexedRes := range resultChan {
		results[indexedRes.index] = indexedRes.result
	}

	return results, nil
}

func readFileList(filelistPath string) ([]string, error) {
	file, err := os.Open(filelistPath)
	if err != nil {
		return nil, err
	}

	defer file.Close()

	var paths []string
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		line := strings.TrimSpace(scanner.Text())
		if line != "" {
			paths = append(paths, line)
		}
	}

	return paths, scanner.Err()
}

func worker(wg *sync.WaitGroup, workChan <-chan workItem, resultChan chan<- indexedResult, timeout int, baseDir string) {
	defer wg.Done()

	for item := range workChan {
		result := processFileWithTimeout(item.path, timeout, baseDir)
		resultChan <- indexedResult{index: item.index, result: result}
	}
}

func processFileWithTimeout(filePath string, timeout int, baseDir string) Result {
	effectiveTimeout := time.Duration(timeout)*time.Second + 200*time.Millisecond
	ctx, cancel := context.WithTimeout(context.Background(), effectiveTimeout)
	defer cancel()

	resultChan := make(chan Result, 1)

	go func() {
		result := doProcessFile(filePath, baseDir, ctx)
		select {
		case resultChan <- result:
		case <-ctx.Done():
		}
	}()

	select {
	case result := <-resultChan:
		return result
	case <-ctx.Done():
		return Result{Path: filePath, Status: "timeout"}
	}
}

func doProcessFile(filePath string, baseDir string, ctx context.Context) Result {
	fullPath := filepath.Join(baseDir, filePath)
	content, err := os.ReadFile(fullPath)
	if err != nil {
		return Result{Path: filePath, Status: "timeout"}
	}

	lines := strings.Split(string(content), "\n")

	startIndex := 0
	if len(lines) > 0 && strings.HasPrefix(lines[0], "#sleep=") {
		sleepStr := strings.TrimPrefix(lines[0], "#sleep=")
		if sleepDuration, err := strconv.Atoi(sleepStr); err == nil {
			select {
			case <-ctx.Done():
				return Result{Path: filePath, Status: "timeout"}
			default:
			}
			
			sleepTimer := time.NewTimer(time.Duration(sleepDuration) * time.Second)
			defer sleepTimer.Stop()
			
			select {
			case <-sleepTimer.C:
			case <-ctx.Done():
				return Result{Path: filePath, Status: "timeout"}
			}
		}
		startIndex = 1
	}

	lineCount := 0
	wordCount := 0

	for i := startIndex; i < len(lines); i++ {
		line := lines[i]
		if i < len(lines)-1 || line != "" {
			lineCount++
		}

		wordCount += len(strings.Fields(line))
	}
	return Result{Path: filePath, Lines: lineCount, Words: wordCount, Status: "ok"}
}

func main() {
	results, err := Aggregate("../data/filelist.txt", 8, 2)
	if err != nil {
		panic(err)
	}

	for _, result := range results {
		if result.Status == "ok" {
			fmt.Printf("%s: %d lines, %d words\n", result.Path, result.Lines, result.Words)
		} else {
			fmt.Printf("%s: %s\n", result.Path, result.Status)
		}
	}
}