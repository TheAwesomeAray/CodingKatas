﻿using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingKatas.LeetCoders
{
    public class AddTwoNumbersTests
    {
        [Theory]
        [InlineData(new[] { 3 }, new[] { 5 }, new[] { 8 })]
        public void AddTwoNumbers_ShouldReturnReversedLinkedListContainingSum(int[] a, int[] b, int[] c)
        {
            var list1 = new LinkedList<int>(a.ToList());
            var list2 = new LinkedList<int>(b.ToList());

            var expected = new LinkedList<int>(c.ToList());

            new AddTwoNumbersKata().AddTwoNumbers(list1, list2).Should().BeEquivalentTo(expected);
        }
    }
}
