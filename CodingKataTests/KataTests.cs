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

        [Theory]
        [InlineData(new int[] { 0, 0, 0, 0 }, 0)]
        [InlineData(new int[] { 1, 1, 1, 1 }, 15)]
        [InlineData(new int[] { 0, 1, 1, 0 }, 6)]
        [InlineData(new int[] { 0, 1, 0, 1 }, 5)]
        public void BinaryArrayToNumberReturnsInt(int[] binaryArray, int expected)
        {
            var actual = OnesAndZeros.BinaryArrayToNumber(binaryArray);

            Assert.Equal(expected, actual);
        }

        public class SumDigitPowerTests
        {
            private string Array2String(long[] list)
            {
                return "[" + string.Join(", ", list) + "]";
            }

            private void CheckResultAsString(long a, long b, long[] res)
            {
                Assert.Equal(Array2String(res), 
                    Array2String(SumDigitPowers.SumDigPow(a, b)));

                Assert.Equal(Array2String(res),
                    Array2String(SumDigitPowersSolution.SumDigPow(a, b)));
            }

            [Fact]
            public void OnlyNumbersWhosSumDigitPowersEqualTheOriginalNumberShouldBeReturned()
            {
                CheckResultAsString(1, 10, new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                CheckResultAsString(1, 100, new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 89 });
                CheckResultAsString(10, 100, new long[] { 89 });
                CheckResultAsString(90, 100, new long[] { });
                CheckResultAsString(90, 150, new long[] { 135 });
                CheckResultAsString(50, 150, new long[] { 89, 135 });
                CheckResultAsString(10, 150, new long[] { 89, 135 });

            }
        }

        public class SupermarketQueueTests
        {
            [Theory]
            [InlineData(new int[] { }, 1, 0)]
            [InlineData(new int[] { 1, 2, 3, 4 }, 1, 10)]
            [InlineData(new int[] { 2, 2, 3, 3, 4, 4 }, 2, 9)]
            [InlineData(new int[] { 1, 2, 3, 4, 5 }, 100, 5)]
            public void ExampleTest1(int[] customers, int registerCount, long expected)
            {
                long actual = SupermarkerQueue.QueueTime(customers, registerCount);
                long solutionActual = SupermarketQueueSolution.QueueTime(customers, registerCount);

                Assert.Equal(expected, actual);
                Assert.Equal(expected, solutionActual);
            }
        }

        public class SimplePigLatinTests
        {
            [Theory]
            [InlineData("Pig", "igPay")]
            [InlineData("Latin", "atinLay")]
            [InlineData("Pig latin is cool", "igPay atinlay siay oolcay")]
            [InlineData("This is my string", "hisTay siay ymay tringsay")]
            public void PigIt_PassedInputString_ReturnsPigLatin(string input, string expected)
            {
                Assert.Equal(expected, SimplePigLatin.PigIt(input));
                Assert.Equal(expected, SimplePigLatinSolution.PigIt(input));
            }

        }

        public class WhoLikesItTests
        {
            [Theory]
            [InlineData(new string[0], "no one likes this")]
            [InlineData(new[] { "Peter" }, "Peter likes this")]
            [InlineData(new[] { "Jacob", "Alex" }, "Jacob and Alex like this")]
            [InlineData(new[] { "Max", "John", "Mark" }, "Max, John and Mark like this")]
            [InlineData(new[] { "Alex", "Jacob", "Mark", "Max" }, "Alex, Jacob and 2 others like this")]
            public void Likes_ArrayOfStrings_ReturnsValidStringResult(string[] input, string expected)
            {
                Assert.Equal(expected, WhoLikesIt.Likes(input));
                Assert.Equal(expected, WhoLikesItSolution.Likes(input));
            }
        }


    }
}
