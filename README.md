# Opendream – Backend Coding Challenge (2025 · 06)

> **Role** Back‑End Developer (Python / C# / Go)
> **Location** Remote‑friendly, HQ in Bangkok
> **Total time budget** ≈ 50 – 65 min

Welcome!
The three micro‑tasks below let us observe the exact skills you’ll use every day on social‑impact platforms such as **Vote62** and **POOPS**—implementation, testing discipline, debugging, and concurrency.

---

## Repository layout

```text
tasks/
├─ 01-run-length/
│   ├─ python/      ← stub + failing tests
│   ├─ go/
│   └─ csharp/
├─ 02-fix-the-bug/
│   ├─ python/
│   ├─ go/
│   └─ csharp/
├─ 03-concurrent-file-stats-processor/   ← new Sync Aggregator task
│   ├─ data/              # input fixtures
│   ├─ python/
│   ├─ go/
│   └─ csharp/
└─ .github/workflows/     ← CI (runs on any change under tasks/)
````

For **each** task pick **one** language (Python ≥ 3.10, Go ≥ 1.22, or C# / .NET 8).
Edit **only** the stub implementation inside `tasks/…/<lang>/`; keep the provided tests unchanged.
Any commit that touches `tasks/` automatically triggers CI.

---

## 1  Challenge menu

| ID | Theme                                   | Est. time   | Mandatory | Who does it   |
| -- | --------------------------------------- | ----------- | --------- | ------------- |
| 01 | Run‑Length Encoder                      | 10 – 15 min | ✔         | Everyone      |
| 02 | Fix‑the‑Bug                             | 15 – 20 min | ✔         | Everyone      |
| 03 | Sync Aggregator (concurrent file stats) | 25 – 30 min | ✔\*       | Mid‑ & Senior |

\* Juniors may stop after Task 02; Seniors continue to Task 04 (SQL) in the private interview follow‑up.

---

## 2  Task specs

<details>
<summary><strong>01 · Run‑Length Encoder</strong></summary>

Implement run‑length encoding: `<char><count>`.

```text
""                              → ""
"XYZ"                           → "X1Y1Z1"
"AAAaaaBBB🦄🦄🦄🦄🦄CCCCCCCCCCCC" → "A3a3B3🦄5C12"
"HAAAAPPY🦄"                    → "H1A4P2Y1🦄1"
```

**Requirements**

* Case‑sensitive
* Handle multi‑digit counts
* Full Unicode (🦄)
* **No** third‑party RLE library

Tests live in each language folder and fail until you implement `encode` / `Encode`.

</details>

<details>
<summary><strong>02 · Fix‑the‑Bug</strong></summary>

The bundled ID generator has a data race that occasionally produces duplicates.

Folder: `tasks/02-fix-the-bug/<lang>/`

Your job:

1. **Do not touch the tests.**
2. Make *one small patch* so all tests go green (`pytest`, `go test -race`, or `dotnet test`).
3. Add ≤ 5 lines at the top of the file explaining **why** the race happened.

</details>

<details>
<summary><strong>03 · Sync Aggregator (concurrent file edition)</strong></summary>

Process a list of local text files **concurrently**—threads / goroutines only (no `async/await`).

### CLI contract

```bash
aggregator --workers=8 --timeout=2 tasks/03-concurrent-file-stats-processor/data/filelist.txt > result.json
```

| Flag        | Meaning                                                      |
| ----------- | ------------------------------------------------------------ |
| `--workers` | Max concurrent workers / goroutines / threads (default = 4). |
| `--timeout` | Per‑file processing budget, **seconds**.                     |

### Expected JSON (stable order)

```json
[
  {"path":"texts/01_lorem.txt","lines":42,"words":273,"status":"ok"},
  {"path":"texts/02_zen.txt","lines":22,"words":145,"status":"ok"},
  {"path":"texts/07_sleep5.txt","status":"timeout"}
]
```

* Omit `lines` / `words` when a timeout occurs.
* Array order **must match** `filelist.txt`.

### Processing rules

1. Read each file.
2. If the first line starts with `#sleep=N`, sleep `N` seconds (simulated slow I/O).
3. Count **lines** and **words**.
4. Abort that file’s work when `timeout` elapses → record `"status":"timeout"`.

### Required function for tests

```python
# tasks/03-concurrent-file-stats-processor/python/aggregator.py
def aggregate(filelist_path: str, workers: int, timeout: int) -> list[dict]: ...
```

(Go & C# versions mirror this signature idiomatically.)

Each language folder includes unit tests asserting:

* Correct line / word counts (given fixture data)
* `"timeout"` status for slow files when `timeout` < sleep
* **Order preservation** of output vs. input list

</details>

---

## 3  What to include in your pull request

Create **one** of the following:

* a `SOLUTIONS.md` file at repo root – **or** –
* a detailed PR **description**.

For **each** task, briefly answer:

| Prompt                | Why we ask                                                    |
| --------------------- | ------------------------------------------------------------- |
| **How** you solved it | Outline the core algorithm / fix in 1‑2 sentences.            |
| **Why** this approach | Note trade‑offs (simplicity, performance, readability, etc.). |
| **Time spent**        | Reality check versus our estimate.                            |

Optional extras:

* Edge cases considered
* What you’d refine with more time
* Links to similar code or blog posts

Template:

```markdown
## Solution notes

### Task 01 – Run‑Length Encoder
- Language: Go
- Approach: [EXPLAIN]
- Why: [EXPLAIN]
- Time spent: ~8 min

### Task 02 – Fix‑the‑Bug
- Language: Python
- Approach: [EXPLAIN]
- Why: [EXPLAIN]
- Time spent: ~6 min

### Task 03 – Sync Aggregator
- Language: C#
- Approach: [EXPLAIN]
- Why: [EXPLAIN]
- Time spent: ~28 min
```

---

## 4  How we evaluate

| Dimension              | What we look for                                              |
| ---------------------- | ------------------------------------------------------------- |
| **Correctness**        | Tests pass; spec satisfied                                    |
| **Readability**        | Clear naming, small functions, helpful comments               |
| **Idiomatic style**    | Follows language norms                                        |
| **Testing discipline** | Provided tests remain intact                                  |
| **Debug & reasoning**  | Comment explains race fix (Task 02) & timeout logic (Task 03) |

Each area scores 0‑3 internally (4‑point rubric).

---

## 5  Submission steps

1. **Fork** this repo.
2. Edit the stub(s) in `tasks/…/<lang>/`.
3. Add your `SOLUTIONS.md` (or PR description).
4. Commit & push.
5. **Open a pull request** against `main`.

CI runs automatically on your branch. When all required tasks are ✅, we’ll contact you to arrange a discussion.

---

## 6  FAQ / Environment

* **Tooling** – `pytest`, `go test`, and `dotnet test` are wired into CI.
* **Dependencies** – you may vendor any OSS library **except** one that already implements RLE or full file‑aggregator functionality.
* **Docker** – not required.
* **Local quick‑tests**

  * `pytest tasks/01-run-length/python`
  * `go test ./tasks/...`
  * `dotnet test ./tasks/...`

---

## 7  Questions?

Open a GitHub Issue or email [jobs@opendream.co.th](mailto:jobs@opendream.co.th).

Happy coding—we can’t wait to read your solutions!

---

<p align="center"><sub>© Opendream 2025 · MIT License for this repo</sub></p>
