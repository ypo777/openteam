using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

public class AggregatorTests
{
    private static readonly Aggregator.Result[] Expected =
    {
        new("texts/01_lorem.txt",     5, 69, "ok"),
        new("texts/02_zen.txt",       8, 39, "ok"),
        new("texts/03_bacon.txt",     3, 38, "ok"),
        new("texts/04_proverbs.txt",  5, 25, "ok"),
        new("texts/05_poem.txt",      5, 37, "ok"),
        new("texts/06_quote.txt",     2, 12, "ok"),
        new("texts/07_sleep5.txt",    0,  0, "timeout"),
        new("texts/08_sleep10.txt",   0,  0, "timeout"),
        new("texts/09_scifi.txt",     4, 47, "ok"),
        new("texts/10_short.txt",     1,  2, "ok"),
        new("texts/11_manifesto.txt", 4, 49, "ok"),
        new("texts/12_jokes.txt",     3, 45, "ok"),
        new("texts/13_ai_ghosts.txt", 6, 83, "ok"),
        new("texts/14_funfacts.txt",  3, 52, "ok"),
        new("texts/15_trivia.txt",    3, 58, "ok"),
    };

    private static readonly string FileList =
        Path.Combine("..", "data", "filelist.txt");

    [Fact]
    public void Aggregate_ProducesExpectedOutput()
    {
        var sw = Stopwatch.StartNew();
        var results = Aggregator.Aggregate(FileList, workers: 8, timeout: 2).ToArray();
        sw.Stop();

        Assert.Equal(Expected.Length, results.Length);

        for (int i = 0; i < results.Length; i++)
        {
            var got  = results[i];
            var want = Expected[i];

            Assert.Equal(want.Path,   got.Path);
            Assert.Equal(want.Status, got.Status);

            if (want.Status == "ok")
            {
                Assert.Equal(want.Lines, got.Lines);
                Assert.Equal(want.Words, got.Words);
            }
        }

        Assert.True(sw.Elapsed < TimeSpan.FromSeconds(6),
            $"Processing too slow ({sw.Elapsed}); expected concurrency.");
    }
}
