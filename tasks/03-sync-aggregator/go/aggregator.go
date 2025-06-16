// Package aggregator – stub for Concurrent File Stats Processor.
package aggregator

import "errors"

// Result mirrors one JSON object in the final array.
type Result struct {
	Path   string `json:"path"`
	Lines  int    `json:"lines,omitempty"`
	Words  int    `json:"words,omitempty"`
	Status string `json:"status"` // "ok" or "timeout"
}

// Aggregate must read filelistPath, spin up *workers* goroutines,
// apply a per‑file timeout, and return results in **input order**.
func Aggregate(filelistPath string, workers, timeout int) ([]Result, error) {
	// ── TODO: IMPLEMENT ────────────────────────────────────────────────────────
	return nil, errors.New("implement Aggregate()")
	// ───────────────────────────────────────────────────────────────────────────
}
