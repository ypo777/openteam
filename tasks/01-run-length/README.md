# Task 1 – Run‑Length Encoder (Algorithms & Data Structures)

This warm-up challenge validates that you can read a small spec, think in O(n), and write clear, test-driven code in the language of your choice.

---

## 1 · Folder Structure

```
tasks/01-run-length/
├─ python/
│   ├─ rle.py                  # ←‑‑‑ implement encode()
│   ├─ test_rle.py             # failing tests
│   └─ fixtures.py             # test cases
├─ go/
│   ├─ go.mod                  # Go module file
│   ├─ rle.go                  # implement Encode()
│   └─ rle_test.go             # failing tests
└─ csharp/
    ├─ Rle.cs                  # implement Encoder.Encode()
    ├─ RleTests.cs             # failing tests
    └─ Rle.csproj              # C# project file
```

Pick **one** language and edit only the stub file.
The tests in that folder will remain red until your function is correct.

---

## 2 · Specification

### 2 · A  Function contract

```text
encode("")                              → ""
encode("XYZ")                           → "X1Y1Z1"
encode("AAAaaaBBB🦄🦄🦄🦄🦄CCCCCCCCCCCC") → "A3a3B3🦄5C12"
encode("HAAAAPPY🦄")                    → "H1A4P2Y1🦄1"
```

| Name     | Type  | Meaning                              |
| -------- | ----- | ------------------------------------ |
| *Input*  | `str` | Any UTF‑8 string (may contain emoji) |
| *Output* | `str` | Run‑length encoding `<char><count>`  |

### 2 · B  Requirements

* **Case‑sensitive**: `A` and `a` are distinct.
* Handle **multi‑digit counts** (`C12`).
* Process **full Unicode** (treat each code‑point / rune as one char).
* Complexity target: **O(n) time, O(n) space**.
* **May not** import a third‑party RLE library (std‑lib string builders are fine).

---

## 3 · Your job

| File            | Function / Method       | Todo                                          |
| --------------- | ----------------------- | --------------------------------------------- |
| `python/rle.py` | `def encode(s)`         | Replace `raise NotImplementedError`           |
| `go/rle.go`     | `func Encode(s)`        | Replace `panic("implement me")`               |
| `csharp/Rle.cs` | `Encoder.Encode()`      | Replace `throw new NotImplementedException()` |

Do **not** edit test files.

---

## 4 · Running the tests locally

```bash
cd tasks/01-run-length

# Python
pytest python/test_rle.py

# Go
go test ./go

# C#
dotnet test ./csharp
```

All suites assert:

1. Correct encoding for four tricky cases.
2. Empty‑string edge case.
3. Unicode (🦄) handled properly.

Tests pass ✅ only when your implementation satisfies every rule.

---

## 5 · Estimated time

A developer comfortable with loops and string builders should finish in **10–15 minutes** including test runs.
Take longer if you need it—quality beats speed.

Good luck 🎯