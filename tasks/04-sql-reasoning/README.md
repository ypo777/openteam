# Task 4 – SQL Reasoning (Data analytics & index design)

This task is **all about writing SQL and thinking about indexes**.
The harness in *Python*, *Go* and *C#* is already wired up; you only need to fill a few string constants.

---

## 1 · Folder scaffold

```
tasks/04‑sql‑reasoning/
├─ donations.db              # SQLite 3.45 database (≈ 50 k pledges)
├─ schema.sql                # Reference DDL (read‑only)
├─ expected/                 # Ground‑truth produced by our reference solution
│   ├─ q1.csv
│   └─ q2.csv
├─ python/
│   ├─ queries.py            # ←‑‑‑ fill SQL_A, SQL_B, INDEXES
│   └─ test_queries.py
├─ go/
│   ├─ queries.go            # same constants for Go
│   └─ queries_test.go
└─ csharp/
    ├─ Queries.cs            # same constants for C#
    └─ QueriesTests.cs
```

*The three language harnesses are identical apart from syntax; pick the one you like or update all three—your call.*

---

## 2 · Schema excerpt

```text
campaign (
    id           INTEGER PRIMARY KEY,
    name         TEXT NOT NULL,
    target_thb   INTEGER NOT NULL CHECK(target_thb > 0),
    owner_id     INTEGER,
    created_at   TEXT  -- ISO‑8601 date string
)

donor (
    id       INTEGER PRIMARY KEY,
    email    TEXT NOT NULL,
    country  TEXT NOT NULL            -- ISO‑3166 English short name
)

pledge (
    id           INTEGER PRIMARY KEY,
    donor_id     INTEGER NOT NULL REFERENCES donor(id),
    campaign_id  INTEGER NOT NULL REFERENCES campaign(id),
    amount_thb   INTEGER NOT NULL,
    pledged_at   TEXT    -- ISO‑8601 date string
)
```

---

## 3 · Your tasks

### **Task A – Total raised per campaign**

Return **one row per campaign** with:

| column          | type | description                                   |
| --------------- | ---- | --------------------------------------------- |
| `campaign_id`   | INT  | `campaign.id`                                 |
| `total_thb`     | INT  | sum of all pledges for that campaign          |
| `pct_of_target` | REAL | `total_thb / target_thb`, **rounded to 4 dp** |

*Order the result by* **`pct_of_target` descending, then `campaign_id` ascending**.

---

### **Task B – 90‑percentile pledge amount**

Produce **exactly two rows**:

| column    | type | value                         | notes                           |
| --------- | ---- | ----------------------------- | ------------------------------- |
| `scope`   | TEXT | `'global'` \| `'thailand'`    | output in this order            |
| `p90_thb` | INT  | 90‑percentile of `amount_thb` | nearest‑rank method (see below) |

*Nearest‑rank rule*:
If a set contains *N* rows ordered ascending by `amount_thb`, the 90‑percentile is the value at rank `ceil(0.9 × N)` (1‑based).

The `thailand` row uses only pledges whose donor’s `country = 'Thailand'` (case‑sensitive).

---

### **Task C – Index advice**

Return **a list / slice / array of exactly two `CREATE INDEX …` statements**:

1. First index must make Task A faster.
2. Second index must make Task B faster.

The tests run `EXPLAIN QUERY PLAN` and assert that **each query performs at least one indexed search** (no full‑table scans).

---

## 4 · Your job

| File                                       | Constant  | Expected value                                     |
| ------------------------------------------ | --------- | -------------------------------------------------- |
| `queries.py` / `queries.go` / `Queries.cs` | `SQL_A`   | your SELECT for Task A                             |
|                                            | `SQL_B`   | your SELECT for Task B                             |
|                                            | `INDEXES` | iterable with exactly two `CREATE INDEX …` strings |

*(The Go and C# test files alias different constant names; follow the in‑file TODOs.)*

---

## 5 · Constraints & rules

* **SQLite version:** 3.45 (bundled with Python 3.12). No extensions loaded.
* **Numeric precision:** use `ROUND(value, 4)` for `pct_of_target`.
* **Do *not* modify** existing tables or data.
* **Keep exactly the requested columns** in exactly the requested order.
* **No peeking**: reading `expected/*.csv` in your solution is forbidden.
* Both queries must run unchanged under the test runner; string formatting is unnecessary.

---

## 6 · Running the tests locally

```bash
cd tasks/04-sql-reasoning

# Python
pytest python/test_queries.py        # requires pytest & sqlite3 std‑lib

# Go
go test ./go

# C#
dotnet test ./csharp
```

Each test suite:

1. Opens *donations.db* in read‑only mode.
2. Creates your indexes (if any).
3. Executes `SQL_A` → exports to `out/q1.csv`.
4. Executes `SQL_B` → exports to `out/q2.csv`.
5. Diffs the outputs against `expected/*.csv`.
6. Verifies both query plans include at least one `SEARCH TABLE … USING INDEX`.

---

## 7 · Estimated time

A senior engineer fluent in SQL window functions and basic indexing needs **\~30 minutes**.

Take your time if you need it—accuracy beats speed.

Good luck 🎯
