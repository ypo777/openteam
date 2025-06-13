# Opendream – Backend Coding Challenge (2025 · 06)

> **Role** Back‑End Developer (Python / C# / Go)
> **Location** Chatuchak, Bangkok
> **Total time budget** ≈ 60 – 120 min

Welcome! The coding challenges below let us observe the exact skills you'll use every day on social‑impact platforms such as **Vote62** and **POOPS**—implementation, testing discipline, debugging, concurrency, and reasoning.

---

## Repository layout

```
tasks/
├─ 01-run-length/
│   ├─ python/
│   ├─ go/
│   └─ csharp/
├─ 02-fix-the-bug/
│   ├─ python/
│   ├─ go/
│   └─ csharp/
├─ 03-sync-aggregator/
│   ├─ data/
│   ├─ python/
│   ├─ go/
│   └─ csharp/
├─ 04-sql-reasoning/
│   ├─ donations.db
│   ├─ expected/
│   ├─ python/
│   ├─ go/
│   └─ csharp/
└─ .github/workflows/       # ← CI (runs on any change under tasks/)
```

For **each** task pick **one** or more language (Python ≥ 3.10, Go ≥ 1.22, or C# / .NET 8).
Edit **only** the stub implementation inside `tasks/…/<lang>/`; **keep the provided tests unchanged**.
Any commit that touches `tasks/` automatically triggers CI.

---

## Challenge menu

⭐️ Any task may be discussed in follow‑up interview ⭐️

| ID | Theme                                     | Est. time   | Mandatory | Who does it   |
| -- | ----------------------------------------- | ----------- | --------- | ------------- |
| 01 | Run‑Length Encoder                        | 10 – 15 min | ✔         | Everyone      |
| 02 | Fix‑the‑Bug (thread safety)               | 10 – 15 min | ✔         | Everyone      |
| 03 | Sync Aggregator (concurrency & I/O)       | 30 – 45 min | ✔*        | Mid‑ & Senior |
| 04 | SQL Reasoning (analytics & optimization)   | 45 – 60 min | ✔**       | Senior only   |

\* Juniors may stop after Task 02
\** Seniors complete all tasks

---

## High-level task specifications

<details>
<summary><strong>01 · Run‑Length Encoder (Algorithms & Data Structures)</strong></summary>

**What:** Implement run‑length encoding: `<char><count>`

**Examples:**
```
""                              → ""
"XYZ"                           → "X1Y1Z1"
"AAAaaaBBB🦄🦄🦄🦄🦄CCCCCCCCCCCC" → "A3a3B3🦄5C12"
```

**Key requirements:**
* Case‑sensitive
* Handle multi‑digit counts
* Full Unicode support
* O(n) time complexity
* No third‑party RLE libraries

**Skills tested:** Basic algorithms, string manipulation, test‑driven development

See `tasks/01-run-length/README.md` for complete specification.

</details>

<details>
<summary><strong>02 · Fix‑the‑Bug (Thread Safety)</strong></summary>

**What:** Fix race condition in ID generator that produces duplicate values

**The problem:** Current implementation has a read‑increment‑write race that causes duplicates under concurrent load

**Your job:**
1. **Do not touch the tests** (they define required behavior)
2. Apply **one small patch** to make ID generation thread‑safe
3. Add ≤ 5 comment lines explaining why the race occurred and how your fix prevents it

**Skills tested:** Concurrency, race condition debugging, atomic operations

See `tasks/02-fix-the-bug/README.md` for complete specification.

</details>

<details>
<summary><strong>03 · Sync Aggregator (Concurrency & I/O)</strong></summary>

**What:** Process multiple text files concurrently with timeout handling and ordered results

**Core challenge:**
* Use worker pools (threads/goroutines, no async/await)
* Handle per‑file timeouts
* Maintain result order matching input list
* Count lines and words efficiently

**Input:** List of file paths (some with `#sleep=N` markers to simulate slow I/O)
**Output:** JSON array with stats or timeout status per file

**Skills tested:** Worker pool patterns, timeout handling, result coordination, I/O processing

See `tasks/03-sync-aggregator/README.md` for complete specification.

</details>

<details>
<summary><strong>04 · SQL Reasoning (Data Analytics & Index Design)</strong></summary>

**What:** Write complex SQL queries and design indexes for a donations database

**Tasks:**
* **Task A:** Campaign performance analysis with percentage calculations
* **Task B:** 90th percentile pledge amounts (global vs Thailand)

**Database:** SQLite with ~100k donation records across campaigns, donors, and pledges

**Skills tested:** Advanced SQL (window functions, aggregations), index design, query optimization

See `tasks/04-sql-reasoning/README.md` for complete specification.

</details>

---

## What to include in your pull request

Create **one** of the following:
* A `SOLUTIONS.md` file at repo root **– or –**
* A detailed PR description

For **each** task you complete, briefly answer:

| Prompt                | Why we ask                                                    |
| --------------------- | ------------------------------------------------------------- |
| **How** you solved it | Outline the core algorithm / fix in 1‑2 sentences            |
| **Why** this approach | Note trade‑offs (simplicity, performance, readability, etc.) |
| **Time spent**        | Reality check versus our estimate                             |

Optional extras:
* Edge cases considered
* What you'd refine with more time
* Tools/AI assistance used (if any)

Template:
```markdown
## Solution notes

### Task 01 – Run‑Length Encoder
- Language: Go
- Approach: [EXPLAIN YOUR ALGORITHM]
- Why: [TRADE-OFFS CONSIDERED]
- Time spent: ~12 min
- AI tools used: [IF ANY]

### Task 02 – Fix‑the‑Bug
- Language: Python
- Approach: [EXPLAIN THE FIX]
- Why: [WHY THIS SOLUTION]
- Time spent: ~8 min

[... continue for each task completed]
```

---

## How we evaluate

| Dimension              | What we look for                                              |
| ---------------------- | ------------------------------------------------------------- |
| **Correctness**        | Tests pass; specification satisfied exactly                   |
| **Code quality**       | Clear naming, appropriate abstractions, readable structure    |
| **Idiomatic style**    | Follows language conventions and best practices               |
| **Testing discipline** | Provided tests remain intact and unmodified                  |
| **Problem solving**    | Sound reasoning in comments and approach documentation        |
| **Performance**        | Efficient algorithms, proper concurrency patterns (Tasks 3‑4) |

Each dimension is scored 0‑3 points internally. We value **quality over speed**—take the time you need to demonstrate your best work.

---

## Submission steps

1. **Fork** this repository
2. **Implement** solutions in `tasks/…/<lang>/` (edit only implementation files)
3. **Document** your approach in `SOLUTIONS.md` or PR description
4. **Commit** and push your changes
5. **Open a pull request** against `main`

CI runs automatically and must pass for your submission to be considered complete.

---

## Environment & FAQ

### Local development
```bash
# Python
pytest tasks/01-run-length/python/
pytest tasks/02-fix-the-bug/python/
pytest tasks/03-sync-aggregator/python/
pytest tasks/04-sql-reasoning/python/

# Go
go test ./tasks/01-run-length/go
go test ./tasks/02-fix-the-bug/go
go test -race ./tasks/03-sync-aggregator/go
go test ./tasks/04-sql-reasoning/go

# C#
dotnet test ./tasks/01-run-length/csharp
dotnet test ./tasks/02-fix-the-bug/csharp
dotnet test ./tasks/03-sync-aggregator/csharp
dotnet test ./tasks/04-sql-reasoning/csharp
```

### Dependencies
* You may use any standard library functionality
* Third‑party libraries are allowed **except** those that directly implement the core challenge (e.g., RLE libraries for Task 1)
* Document any external dependencies in your solution notes

### AI tools & assistance
* **AI coding assistants are welcome** (Copilot, Claude, ChatGPT, etc.)
* We encourage using tools that help you write better code faster
* **Please mention** any AI assistance in your PR/solutions document
* What matters is your **understanding** and **reasoning** about the solution, please document them in `SOLUTIONS.md`

### Best practices
* Use your **best judgment** and professional experience
* **Quality over speed** – we prefer well‑written solutions that take longer
* **Test locally** before submitting to ensure CI will pass
* **Read the task READMEs carefully** – they contain essential details

### Common questions
* **Q:** Can I modify test files?
  **A:** No, keep all test files unchanged

* **Q:** What if I get stuck on a task?
  **A:** Submit what you have with clear documentation of your approach and challenges faced

* **Q:** Can I implement multiple languages for the same task?
  **A:** Yes, though one language per task is sufficient

* **Q:** How strictly are time estimates enforced?
  **A:** They're guidelines – focus on quality solutions rather than speed

---

## Questions?

Open a GitHub Issue or email [jobs@opendream.co.th](mailto:jobs@opendream.co.th).

We expect candidates to use their professional judgment and problem‑solving abilities. Show us how you approach real‑world development challenges!

Happy coding—we can't wait to review your solutions! 🎯

---

<p align="center"><sub>© Opendream 2025 · MIT License for this repo</sub></p>