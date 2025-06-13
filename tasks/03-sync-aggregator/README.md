# Task 3 – Sync Aggregator (Concurrency & I/O)

This challenge measures your ability to coordinate multiple workers, enforce time‑based cancellation, and collate ordered results—all while keeping the code clean and test‑driven.

---

## 1 · Folder Structure

```
tasks/03-sync-aggregator/
├─ data/
│  ├─ filelist.txt         # 15 relative paths, one per line
│  └─ texts/               # sample input files (some start with #sleep=N)
├─ python/
│  ├─ aggregator.py        # ←‑‑‑ implement aggregate()
│  └─ test_aggregator.py   # reference tests – must stay green
├─ go/
│  ├─ go.mod               # Go module file
│  ├─ aggregator.go        # implement Aggregate()
│  └─ aggregator_test.go   # failing tests
└─ csharp/
   ├─ Aggregator.csproj    # project file with xUnit refs
   ├─ Aggregator.cs        # implement Aggregator.Aggregate()
   └─ AggregatorTests.cs   # failing tests
```

Pick **one** language and edit only the implementation file.
The tests in that folder will remain red until your implementation is correct.

---

## 2 · Specification

### CLI contract

```bash
aggregator --workers=8 --timeout=2 data/filelist.txt  ➜  result.json
```

| Flag        | Meaning                                        | Default |
| ----------- | ---------------------------------------------- | ------- |
| `--workers` | Maximum concurrent worker threads / goroutines | `4`     |
| `--timeout` | **Per‑file** processing budget in seconds      | `2`     |

### Processing rules

1. Iterate through **`filelist.txt`** (one relative path per line).
2. If the first line of a file starts with **`#sleep=N`**, pause *N* seconds *then discard that marker line*—it **must not** be counted in `lines`/`words`.
3. Count
   * *Lines*: newline‑terminated lines after the marker (if any).
   * *Words*: ASCII‑whitespace‑separated tokens in those lines.
4. Abandon work on a file that exceeds `--timeout` and record a timeout.
5. Produce results **in the same order** as `filelist.txt`.

### Output format

```jsonc
// success
{"path":"texts/01_lorem.txt","lines":5,"words":69,"status":"ok"}

// timeout
{"path":"texts/07_sleep5.txt","status":"timeout"}
```

*Omit `lines` and `words` on timeouts.*
Return an array whose order **exactly matches** the input list.

---

## 3 · Your job

| File                   | Function / Method                       | Todo                                  |
| ---------------------- | --------------------------------------- | ------------------------------------- |
| `python/aggregator.py` | `aggregate(filelist, workers, timeout)` | Replace `raise NotImplementedError`   |
| `go/aggregator.go`     | `Aggregate(filelist, workers, timeout)` | Replace `errors.New("implement")`     |
| `csharp/Aggregator.cs` | `Aggregator.Aggregate(...)`             | Replace `throw new NotImplemented...` |

**Do not** edit test files.

---

## 4 · Running the tests locally

```bash
cd tasks/03-sync-aggregator

# Python
pytest python/test_aggregator.py

# Go
go test -race ./go

# C#
dotnet test ./csharp
```

The suites assert:

1. All 15 records exactly match ground‑truth stats / timeouts.
2. Array order preserved.
3. Runs in < 6 s on reference data (verifies real concurrency).

Tests pass ✅ only when your implementation correctly handles concurrency and timeouts.

---

## 5 · Estimated time

Mid‑level engineers typically finish in **30–45 minutes** including test runs.
This task requires understanding of concurrency patterns, worker pools, and timeout handling.

Take longer if you need it—quality concurrent code is challenging to get right.

Good luck 🎯