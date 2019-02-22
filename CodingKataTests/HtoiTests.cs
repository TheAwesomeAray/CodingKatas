using CodingKatas;
using FluentAssertions;
using Xunit;

public class HtoiTests
{
    [Theory]
    [InlineData("0x0", 0)]
    [InlineData("0x1", 1)]
    [InlineData("0x12", 18)]
    public void Htoi_GivenHexidecimalValueBetween0And9_ReturnsConvertedInteger(string input, int expected)
    {
        new HtoiKata().Htoi(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("0xA", 10)]
    [InlineData("0xC", 12)]
    [InlineData("0xF", 15)]
    public void Htoi_GivenHexidecimalValueOfUpperCaseCharacters_ReturnsConvertedInteger(string input, int expected)
    {
        new HtoiKata().Htoi(input).Should().Be(expected);
    }
}

