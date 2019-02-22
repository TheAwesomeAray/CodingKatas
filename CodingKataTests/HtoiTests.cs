using CodingKatas;
using FluentAssertions;
using System;
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

    [Theory]
    [InlineData("0xa12F", 41263)]
    [InlineData("0X123ABc", 1194684)]
    [InlineData("0xa9b2C5", 11121349)]
    public void Htoi_GivenHexidecimalValue_ReturnsConvertedInteger(string input, int expected)
    {
        new HtoiKata().Htoi(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("a12F", 41263)]
    [InlineData("123ABc", 1194684)]
    [InlineData("a9b2C5", 11121349)]
    public void Htoi_GivenHexidecimalValueWithout0x_ReturnsConvertedInteger(string input, int expected)
    {
        new HtoiKata().Htoi(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("a12FG")]
    [InlineData("x123ABc")]
    [InlineData("a9b2C5`")]
    public void Htoi_GivenInvalidHexidecimal_Returns0(string input)
    {
        Assert.Throws<InvalidOperationException>(() => new HtoiKata().Htoi(input));
    }
}

