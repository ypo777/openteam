using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BuggyLib.Tests;

public class BuggyCounterTests
{
    [Fact]
    public void NextId_Should_Not_Duplicate()
    {
        const int N = 5_000;

        var bag = new ConcurrentBag<long>();
        Parallel.For(0, N, _ => bag.Add(BuggyCounter.NextId()));

        int duplicates = bag.Count - bag.Distinct().Count();
        Assert.Equal(0, duplicates);  // ⬅️ will FAIL until race fixed
    }
}
