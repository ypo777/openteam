package rle

import (
	"strconv"
	"strings"
)
// Encode returns the run‑length encoding of UTF‑8 string s.
//
// "AAB" → "A2B1"
func Encode(s string) string {
	if len(s) == 0 {
		return ""
	}

	var result strings.Builder
	runes := []rune(s)

	currentChar := runes[0]
	count := 1

	for i:=1; i < len(runes); i++{
		if runes[i] == currentChar {
			count++
		}else{
			result.WriteRune(currentChar)
			result.WriteString(strconv.Itoa(count))

			currentChar = runes[i]
			count = 1
		}
	}
	result.WriteRune(currentChar)
	result.WriteString(strconv.Itoa(count))

	return result.String()
}
