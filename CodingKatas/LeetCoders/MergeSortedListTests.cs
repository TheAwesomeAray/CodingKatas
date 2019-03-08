﻿using FluentAssertions;
using System.Linq;
using Xunit;

namespace CodingKatas.LeetCoders
{
    public class MergeSortedListTests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3}, new[] { 4, 5, 6 },
            new[] { 1, 2, 3, 4, 5, 6 })]
        public void Sort_ReturnsSortedList(int[] a, int[] b, int[] expected)
        {
            new MergeSortedListKata().Sort(a.ToList(), b.ToList()).Should().BeEquivalentTo(expected.ToList());
        }
    }
}
