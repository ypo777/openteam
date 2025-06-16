using Xunit;
using Rle;

public class RleTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("XYZ", "X1Y1Z1")]
    [InlineData("AAAaaaBBB🦄🦄🦄🦄🦄CCCCCCCCCCCC", "A3a3B3🦄5C12")]
    [InlineData("HAAAAPPY🦄", "H1A4P2Y1🦄1")]
    public void Encode_Works(string raw, string expected)
        => Assert.Equal(expected, Encoder.Encode(raw));
}
