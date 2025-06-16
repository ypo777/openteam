using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public static class Aggregator
{
    public record Result(string Path, int Lines, int Words, string Status);

    /// <summary>
    /// Concurrently processes the files listed in <paramref name="fileListPath"/>.
    /// Must preserve input order and apply a per‑file timeout.
    /// </summary>
    public static IEnumerable<Result> Aggregate(
        string fileListPath,
        int workers = 4,
        int timeout = 2)
    {
        // ── TODO: IMPLEMENT ────────────────────────────────────────────────────
        throw new NotImplementedException("implement Aggregate()");
        // ───────────────────────────────────────────────────────────────────────
    }
}
