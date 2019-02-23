using CodingKatas;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
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
}

