using CodingKatas;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [Theory, ClassData(typeof(FindTheSmallestTestData))]
        public void FindTheSmallestTest(List<int> argument, List<int> expectedResult)
        {
            Assert.Equal(expectedResult, RemoveTheMinimum.RemoveSmallest(argument));
            Assert.Equal(expectedResult, RemoveTheMinimumSolution.RemoveSmallest(argument));
        }

        public class FindTheSmallestTestData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {
                    new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 2, 3, 4, 5 }
                },
                new object[] {
                    new List<int> { 5, 3, 2, 1, 4 }, new List<int> { 5, 3, 2, 4 }
                },
                new object[] {
                    new List<int> { 1, 2, 3, 1, 1 }, new List<int> { 2, 3, 1, 1 }
                },
                new object[] {
                    new List<int>(), new List<int>()
                }
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

    }
}
