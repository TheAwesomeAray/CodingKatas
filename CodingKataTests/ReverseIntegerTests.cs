using CodingKatas;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

public class ReverseIntegerTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(12, 21)]
    [InlineData(120, 21)]
    public void Reverse_GivenPositiveInteger_ReturnsReversedInteger(int input, int expected)
    {
        new ReverseIntegerKata().Reverse(input).Should().Be(expected);
    }

    [Theory]
    [InlineData(-1, -1)]
    [InlineData(-12, -21)]
    public void Reverse_GivenNegativeInteger_ReturnsReversedInteger(int input, int expected)
    {
        new ReverseIntegerKata().Reverse(input).Should().Be(expected);
    }
}

