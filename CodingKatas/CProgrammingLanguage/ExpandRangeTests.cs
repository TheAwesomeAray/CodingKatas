using CodingKatas;
using FluentAssertions;
using Xunit;

public class ExpandRangeTests
{
    [Theory]
    [InlineData("a-c", "abc")]
    [InlineData("c-e", "cde")]
    [InlineData("a-z", "abcdefghijklmnopqrstuvwxyz")]
    public void Expand_GivenRangeOfLowerCaseLetters_ReturnsExpandedRange(string input, string expected)
    {
        new ExpandRangeKata().Expand(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("a-cf-j", "abcfghij")]
    [InlineData("c-ex-z", "cdexyz")]
    [InlineData("a-za-z", "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
    public void Expand_GivenMultipleRangesOfLowerCaseLetters_ReturnsExpandedRange(string input, string expected)
    {
        new ExpandRangeKata().Expand(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("A-CF-J", "ABCFGHIJ")]
    [InlineData("C-EX-Z", "CDEXYZ")]
    [InlineData("A-ZA-Z", "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ")]
    public void Expand_GivenMultipleRangesOfUpperCaseLetters_ReturnsExpandedRange(string input, string expected)
    {
        new ExpandRangeKata().Expand(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("1-35-9", "12356789")]
    [InlineData("0-91-9", "0123456789123456789")]
    public void Expand_GivenMultipleRangesOfDigits_ReturnsExpandedRange(string input, string expected)
    {
        new ExpandRangeKata().Expand(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("a-z0-9", "abcdefghijklmnopqrstuvwxyz0123456789")]
    [InlineData("A-Cd-g1-9", "ABCdefg123456789")]
    public void Expand_GivenCombinationOfInputs_ReturnsExpandedRange(string input, string expected)
    {
        new ExpandRangeKata().Expand(input).Should().Be(expected);
    }
}

