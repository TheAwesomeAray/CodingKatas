using CodingKatas;
using FluentAssertions;
using Xunit;

public class HtoiTests
{
    [Theory]
    [InlineData("0x0", 0)]
    [InlineData("0x1", 1)]
    public void Htoi_GivenHexidecimalValue_ReturnsConvertedInteger(string input, int expected)
    {
        new HtoiKata().Htoi(input).Should().Be(expected);
    }
}

