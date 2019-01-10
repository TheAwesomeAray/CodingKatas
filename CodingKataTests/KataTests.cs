using CodingKatas;
using Xunit;

namespace CodingKataTests
{
    public class KataTests
    {
        [Fact]
        public void DescendingOrderTest()
        {
            Assert.Equal(54321, DescendingOrderKata.DescendingOrder(12345));
            Assert.Equal(54321, DescendingOrderKataSolution.DescendingOrder(12345));
        }

        [Fact]
        public void ExesAndOhsTest()
        {
            Assert.True(ExesAndOhs.XO("xo"));
            Assert.True(ExesAndOhs.XO("xxOo"));
            Assert.False(ExesAndOhs.XO("xxxm"));
            Assert.False(ExesAndOhs.XO("Oo"));
            Assert.False(ExesAndOhs.XO("ooom"));

            Assert.True(ExesAndOhsSolution.XO("xo"));
            Assert.True(ExesAndOhsSolution.XO("xxOo"));
            Assert.False(ExesAndOhsSolution.XO("xxxm"));
            Assert.False(ExesAndOhsSolution.XO("Oo"));
            Assert.False(ExesAndOhsSolution.XO("ooom"));
        }

        [Fact]
        public void CountBitsTest()
        {
            Assert.Equal(0, BitCounting.CountBits(0));
            Assert.Equal(1, BitCounting.CountBits(4));
            Assert.Equal(3, BitCounting.CountBits(7));
            Assert.Equal(2, BitCounting.CountBits(9));
            Assert.Equal(2, BitCounting.CountBits(10));

            Assert.Equal(0, BitCountingSolution.CountBits(0));
            Assert.Equal(1, BitCountingSolution.CountBits(4));
            Assert.Equal(3, BitCountingSolution.CountBits(7));
            Assert.Equal(2, BitCountingSolution.CountBits(9));
            Assert.Equal(2, BitCountingSolution.CountBits(10));
        }

        [Fact]
        public void FindTheOddIntTest()
        {
            Assert.Equal(5, FindTheOddInt.Find(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
            Assert.Equal(5, FindTheOddIntSolution.Find(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
        }
    }
}
