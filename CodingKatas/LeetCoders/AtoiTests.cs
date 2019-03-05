using CodingKatas.LeetCoders;
using FluentAssertions;
using Xunit;

public class AtoiTests
{
    [Theory]
    [InlineData("1", 1)]
    [InlineData("12", 12)]
    public void Atoi_ConvertsStringToInteger(string input, int expected)
    {
        new AtoiKata().Atoi(input).Should().Be(expected);
    }
}

