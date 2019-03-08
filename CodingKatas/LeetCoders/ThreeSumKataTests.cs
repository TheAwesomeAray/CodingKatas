using FluentAssertions;
using Xunit;

namespace CodingKatas.LeetCoders
{
    public class ThreeSumKataTests
    {
        [Theory]
        [InlineData(new[] { -1, 0, 1, 2, -1, -4 })]
        public void ThreeSum_ReturnsCombinationOfThreeNumbersWhoHaveSumOfZero(int[] input)
        {
            var expected = new[] { new[] { -1, 0, 1 }, new[] { -1, 2, -1 } };
            new ThreeSumKata().ThreeSum(input).Should().BeEquivalentTo(expected);
        }
    }
}
