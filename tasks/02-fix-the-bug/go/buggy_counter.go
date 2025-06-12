package counter

import "time"

var current int64

func NextID() int64 {
	id := current
	time.Sleep(0)
	current++
	return id
}
