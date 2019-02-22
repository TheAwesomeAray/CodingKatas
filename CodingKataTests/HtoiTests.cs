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
    [InlineData("0xAF", 175)]
    [InlineData("0xABCDEF", 11259375)]
    public void Htoi_GivenHexidecimalValueOfUpperCaseCharacters_ReturnsConvertedInteger(string input, int expected)
    {
        new HtoiKata().Htoi(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("0xa", 10)]
    [InlineData("0xb", 11)]
    [InlineData("0xd", 13)]
    [InlineData("0xaf", 175)]
    [InlineData("0xfedcba", 16702650)]
    public void Htoi_GivenHexidecimalValueOfLowerCaseCharacters_ReturnsConvertedInteger(string input, int expected)
    {
        new HtoiKata().Htoi(input).Should().Be(expected);
    }
}

