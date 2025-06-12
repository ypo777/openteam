// BuggyLib/BuggyCounter.cs
namespace BuggyLib;

public static class BuggyCounter
{
    private static long _current = 0;

    public static long NextId()
    {
        long value = _current;
        System.Threading.Thread.Sleep(0);
        _current++;
        return value;
    }
}
