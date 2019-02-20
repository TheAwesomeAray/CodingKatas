using CodingKatas;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

public class TwoSumTests
{
    [Theory]
    [InlineData(new[] { 1, 0 }, 1, new[] { 0, 1 })]
    [InlineData(new[] { 1, 2, 3 }, 4, new[] { 0, 2 })]
    [InlineData(new[] { 1, 15, 25, 100 }, 125, new[] { 2, 3 })]
    public void TwoSum_GivenArrayAndTarget_ReturnsIndicesThatEqualTarget(int[] input, int target, int[] expected)
    {
        expected.Should().BeEquivalentTo(new TwoSumKata().TwoSum(input, target));
    }
}

