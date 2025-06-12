# Opendream – Backend Coding Challenge (2025 · 06)

> **Role**  Back-End Developer (Python / C# / Go)
> **Location**  Remote-friendly, HQ in Bangkok
> **Time budget**  ≈ 15 min total

Welcome!
The two micro-tasks below give us a clear window into your code style, testing habits, and debugging approach—the exact skills you’ll use every day on social-impact platforms such as **Vote62** and **POOPS**.

---

## Repository Layout

```

tasks/
├─ 01-run-length/
│   ├─ python/   ← stub + failing tests
│   ├─ go/
│   └─ csharp/
└─ 02-fix-the-bug/
│   ├─ python/   ← stub + failing tests
│   ├─ go/
│   └─ csharp/
.github/workflows/   ← CI (runs on any change under tasks/)

````

For **each** task pick **one** language (Python ≥ 3.10, Go ≥ 1.22, or C# / .NET 8).
Edit **only** the stub implementation inside `tasks/…/<lang>/`; keep the provided tests unchanged.
Commits to any file under `tasks/` automatically trigger CI.

---

## 1 Challenge Menu

| ID | Theme              | Est. time | Mandatory? | Who does it? |
|----|--------------------|-----------|------------|--------------|
| 01 | Run-Length Encoder | 10 – 15 min | ✔ | Everyone |
| 02 | Fix-the-Bug        | 15 – 20 min | ✔ | Everyone |

---

## 2 Task Specs

<details>
<summary><strong>01 · Run-Length Encoder</strong></summary>

Implement run-length encoding: `<char><count>`.

```text
""                              → ""
"XYZ"                           → "X1Y1Z1"
"AAAaaaBBB🦄🦄🦄🦄🦄CCCCCCCCCCCC" → "A3a3B3🦄5C12"
"HAAAAPPY🦄"                    → "H1A4P2Y1🦄1"
````

* Requirements

  * Case-sensitive.
  * Handle multi-digit counts.
  * Full Unicode (🦄).
  * **No** third-party RLE library.
* Tests live in each language folder and fail until you implement `encode` / `Encode`.

</details>

<details>
<summary><strong>02 · Fix-the-Bug</strong></summary>

The bundled ID generator has a data race and produces duplicates.

* Folder `tasks/02-fix-the-bug/<lang>/` contains

  * `buggy_counter.*`  ← faulty implementation
  * `test_counter.*`   ← failing test
* Your job

  1. **Do not touch the tests.**
  2. Make *one small patch* so the tests go green (`pytest`, `go test -race`, or `dotnet test`).
  3. Add ≤ 5 lines at the top of the file explaining *why* the race happened.

</details>

---

## 3 What to Include in Your Pull Request

Create **one** of the following:

1. **`SOLUTIONS.md` at repo root** – or –
2. A detailed PR **description**.

Either way, cover these three bullet points per task:

| Prompt                | Why we ask                                                           |
| --------------------- | -------------------------------------------------------------------- |
| **How** you solved it | Outline core algorithm / fix in 1-2 sentences.                       |
| **Why** this approach | Trade-offs you weighed (simplicity, performance, readability, etc.). |
| **Time spent**        | Reality check vs. our estimate.                                      |

*Optional extras* (nice to see, never required):

* Edge cases you considered.
* If you had more time, what you’d refine.
* Links to similar code you’ve written or blog posts you drew on.

A minimal template you can copy:

```markdown
## Solution notes

### Task 01 – Run-Length Encoder
- Language: Go
- Approach: [EXPLAIN HERE]
- Why: [EXPLAIN HERE]
- Time spent: ~8 min

### Task 02 – Fix-the-Bug
- Language: Python
- Approach: [EXPLAIN HERE]
- Why: [EXPLAIN HERE]
- Time spent: ~6 min
```

---

## 4 How We Evaluate

| Dimension              | What we look for                                |
| ---------------------- | ----------------------------------------------- |
| **Correctness**        | Tests pass; spec satisfied                      |
| **Readability**        | Clear naming, small functions, helpful comments |
| **Idiomatic Style**    | Follows language norms                          |
| **Testing Discipline** | Provided tests remain intact                    |
| **Debug & Reasoning**  | Comment explains the race fix in Task 02        |

Each area scores 0-3 internally (4-point rubric).

---

## 5 Submission Steps

1. **Fork** this repo.
2. Edit the stub(s) in `tasks/…/<lang>/`.
3. Add your `SOLUTIONS.md` (or PR description).
4. Commit & push.
5. **Open a pull request** against `main`.

CI will run automatically on your forked branch. When both tasks are ✅, we’ll contact you to arrange a discussion.

---

## 6 FAQ / Environment

* **Tooling available** – `pytest`, `go test`, `dotnet test` already wired in CI.
* **Dependencies** – you may vendor any OSS library **except** one that already implements RLE.
* **Docker** – not required.
* **Local test** – `pytest tasks/01-run-length/python`, `go test ./tasks/...`, `dotnet test ...`.

---

## 7 Questions?

Open a GitHub Issue or email [jobs@opendream.co.th](mailto:jobs@opendream.co.th).
Happy coding—can’t wait to read your solutions!

---

<p align="center"><sub>© Opendream 2025 · MIT License for this repo</sub></p>
