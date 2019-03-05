using CodingKatas.LeetCoders;
using FluentAssertions;
using Xunit;

public class AtoiTests
{
    [Theory]
    [InlineData("1", 1)]
    [InlineData("12", 12)]
    [InlineData("952", 952)]
    public void Atoi_ConvertsPositiveStringToInteger(string input, int expected)
    {
        new AtoiKata().Atoi(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("-1", -1)]
    public void Atoi_ConvertsStringContainingNegativeIntegerToInteger(string input, int expected)
    {
        new AtoiKata().Atoi(input).Should().Be(expected);
    }
}

