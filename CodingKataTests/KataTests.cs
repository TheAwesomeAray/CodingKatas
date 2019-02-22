using CodingKatas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public class CamelCaseTests
        {
            [Theory]
            [InlineData("the_stealth_warrior", "theStealthWarrior")]
            [InlineData("The-Stealth-Warrior", "TheStealthWarrior")]
            public void ToCamelCase_ConvertsInputToCamelCase(string input, string expected)
            {
                string actual = ToCamelCaseKata.ToCamelCase(input);

                Assert.Equal(expected, actual);
            }
        }

        public class TribonacciTests
        {
            [Theory]
            [InlineData(new double[] { 1, 1, 1 }, 4, new double[] { 1, 1, 1, 3 })]
            [InlineData(new double[] { 1, 1, 1 }, 10, new double[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105 })]
            [InlineData(new double[] { 0, 0, 1 }, 10, new double[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 })]
            [InlineData(new double[] { 0, 1, 1 }, 10, new double[] { 0, 1, 1, 2, 4, 7, 13, 24, 44, 81 })]
            [InlineData(new double[] { 0 }, 2, new double[] { 0, 0 })]
            public void Tribonacci_GivenSequenceAndIterations_ReturnsResult(
                double[] sequence, int n, double[] expected)
            {
                Assert.Equal(expected, new Xbonacci().Tribonacci(sequence, n));
            }
        }

        public class PaginationHelperTests
        {
            private readonly List<int> collection;
            private PaginationHelper<int> helper;

            public PaginationHelperTests()
            {
                collection = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
                                            14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
                helper = new PaginationHelper<int>(collection, 10);
            }


            [Theory]
            [InlineData(-1, -1)]
            [InlineData(1, 10)]
            [InlineData(3, -1)]
            public void PageItemCountTest(int pageIndex, int expected)
            {
                Assert.Equal(expected, helper.PageItemCount(pageIndex));
            }

            [Theory]
            [InlineData(-1, -1)]
            [InlineData(12, 1)]
            [InlineData(24, -1)]
            public void PageIndexTest(int itemIndex, int expected)
            {
                Assert.Equal(expected, helper.PageIndex(itemIndex));
            }

            [Fact]
            public void ItemCountTest()
            {
                Assert.Equal(24, helper.ItemCount);
            }

            [Fact]
            public void PageCountTest()
            {
                Assert.Equal(3, helper.PageCount);
            }
        }

        public class WordSuggestionTests
        {
            [Theory]
            [InlineData("java", "heaven", new[] { "javascript", "java", "ruby", "php", "python", "coffeescript" })]
            [InlineData("javascript", "javascript", new[] { "javascript", "java", "ruby", "php", "python", "coffeescript" })]
            [InlineData("strawberry", "strawbery", new[] { "cherry", "pineapple", "melon", "strawberry", "raspberry" })]
            [InlineData("cherry", "berry", new[] { "cherry", "pineapple", "melon", "strawberry", "raspberry" })]
            public void FindMostSimilar_GivenStringInput_ReturnsMostSimilarWordInDictionary(string expected, string searchTerm, string[] dictionary)
            {
                WordSuggestion kata = new WordSuggestion(dictionary);
                Assert.Equal(expected, kata.FindMostSimilar(searchTerm));
            }
        }

        public class SudokuTests
        {
            [Fact]
            public void ValidatesLargeSudokuPuzzle()
            {
                var goodSudoku1 = new Sudoku(
                  new int[][] {
                      new int[] {7,8,4, 1,5,9, 3,2,6},
                      new int[] {5,3,9, 6,7,2, 8,4,1},
                      new int[] {6,1,2, 4,3,8, 7,5,9},

                      new int[] {9,2,8, 7,1,5, 4,6,3},
                      new int[] {3,5,7, 8,4,6, 1,9,2},
                      new int[] {4,6,1, 9,2,3, 5,8,7},

                      new int[] {8,7,6, 3,9,4, 2,1,5},
                      new int[] {2,4,3, 5,6,1, 9,7,8},
                      new int[] {1,9,5, 2,8,7, 6,3,4}
                  });
                Assert.True(goodSudoku1.IsValid());
            }

            [Fact]
            public void Test()
            {
                var goodSudoku1 = new Sudoku(
                  new int[][] {
                      new int[] {1, 2, 3,   4, 5, 6,   7, 8, 9},
                      new int[] {2, 3, 1,   5, 6, 4,   8, 9, 7},
                      new int[] {3, 1, 2,   6, 4, 5,   9, 7, 8},

                      new int[] {4, 5, 6,   7, 8, 9,   1, 2, 3},
                      new int[] {5, 6, 4,   8, 9, 7,   2, 3, 1},
                      new int[] {6, 4, 5,   9, 7, 8,   3, 1, 2},

                      new int[] {7, 8, 9,   1, 2, 3,   4, 5, 6},
                      new int[] {8, 9, 7,   2, 3, 1,   5, 6, 4},
                      new int[] { 9, 7, 8, 3, 1, 2, 6, 4, 5 }
                  });
                Assert.False(goodSudoku1.IsValid());
            }

            [Fact]
            public void ValidatesSmallSudokuPuzzle()
            {
                var sudoku = new Sudoku(
                  new int[][] {
                      new int[] {1,2, 3,4},
                      new int[] {2,3, 4,1},

                      new int[] {3,4, 1 ,2},
                      new int[] {4,1, 2 ,3}
                });
                Assert.False(sudoku.IsValid());
            }

            [Fact]
            public void Test2()
            {
                var goodSudoku2 = new Sudoku(
                  new int[][] {
                      new int[] {1,4, 2,3},
                      new int[] {3,2, 4,1},

                      new int[] {4,1, 3,2},
                      new int[] {2,3, 1,4}
                });
                Assert.True(goodSudoku2.IsValid());
            }

            [Fact]
            public void CannotContainDuplicatesOnYAxis()
            {
                var badSudoku1 = new Sudoku(
                  new int[][] {
                      new int[] {1,2,3, 4,5,6, 7,8,9},
                      new int[] {1,2,3, 4,5,6, 7,8,9},
                      new int[] {1,2,3, 4,5,6, 7,8,9},

                      new int[] {1,2,3, 4,5,6, 7,8,9},
                      new int[] {1,2,3, 4,5,6, 7,8,9},
                      new int[] {1,2,3, 4,5,6, 7,8,9},

                      new int[] {1,2,3, 4,5,6, 7,8,9},
                      new int[] {1,2,3, 4,5,6, 7,8,9},
                      new int[] {1,2,3, 4,5,6, 7,8,9,}
                  });
                Assert.False(badSudoku1.IsValid());
            }

            [Fact]
            public void CannotContainDuplicateOnXAxis()
            {
                var goodSudoku2 = new Sudoku(
                  new int[][] {
                      new int[] {1,4, 2,1},
                      new int[] {3,2, 4,1},

                      new int[] {4,1, 3,2},
                      new int[] {2,3, 1,4}
                });
                Assert.False(goodSudoku2.IsValid());
            }

            [Fact]
            public void CannotContainInconsistentArraySizes()
            {
                var badSudoku2 = new Sudoku(
                  new int[][] {
                      new int[] {1,2,3,4,5},
                      new int[] {1,2,3,4,5},

                      new int[] {1,2,3,4},
                      new int[] {1}
                });
                Assert.False(badSudoku2.IsValid());
            }

            [Fact]
            public void CannotContainValuesOutsideOfValidRange()
            {
                var goodSudoku2 = new Sudoku(
                  new int[][] {
                      new int[] {1,4, 2,3},
                      new int[] {3,2, 5,1},

                      new int[] {4,1, 3,2},
                      new int[] {2,3, 1,4}
                });
                Assert.False(goodSudoku2.IsValid());
            }


            [Fact]
            public void CannotContainNegativeValues()
            {
                var goodSudoku2 = new Sudoku(
                  new int[][] {
                      new int[] {1, 2, 3,3},
                      new int[] {2,2, 3,-1},

                      new int[] {3,1, 3,2}
                });
                Assert.False(goodSudoku2.IsValid());
            }
        }

        public class Rot13Tests
        {
            [Fact]
            public void CorrectlyDeciphersString()
            {
                Assert.Equal("ROT13 example.", Rot13.Decipher("EBG13 rknzcyr."));
            }
        }

        public class JosephusSurvivorTests
        {
            [Theory]
            [InlineData(7, 3, 4)]
            [InlineData(11, 19, 10)]
            [InlineData(40, 3, 28)]
            public void ReturnsExpectedResult(int n, int k, int expected)
            {
                var actual = JosephusSurvivor.FindSurvivor(n, k);
                Assert.Equal(expected, actual);
            }

        }

        public class VolumeCalculatorTests
        {
            [Theory]
            [InlineData(5, 7, 3848, 2940)]
            [InlineData(2, 7, 3848, 907)]
            [InlineData(80, 120, 3500, 2478)]
            public void CalculateVolumeReturnsCorrectResult(int height, int diameter, int volumeTotal, int expected)
            {
                Assert.Equal(expected, VolumeCalculator.CalculateVolume(height, diameter, volumeTotal));
            }
        }

        public class SumByFactorsTests
        {
            [Theory]
            [InlineData(new[] { 12 }, "(2 12)(3 12)")]
            [InlineData(new[] { 12, 15 }, "(2 12)(3 27)(5 15)")]
            [InlineData(new[] { 15, 21, 24, 30, 45 }, "(2 54)(3 135)(5 90)(7 21)")]
            [InlineData(new[] { 454, 60, 398, 192, 235, 316, 464, -39, 63, 487, 334, 242, 315, 378, 186 },
                "(2 3024)(3 1155)(5 610)(7 756)(11 242)(13 -39)(29 464)(31 186)(47 235)(79 316)(167 334)(199 398)(227 454)(487 487)")]
            [InlineData(new[] { -29804, -4209, -28265, -72769, -31744 },
                "(2 -61548)(3 -4209)(5 -28265)(23 -4209)(31 -31744)(53 -72769)(61 -4209)(1373 -72769)(5653 -28265)(7451 -29804)")]
            public void Test1(int[] input, string expected)
            {
                Assert.Equal(expected, SumOfDivided.sumOfDivided(input));
            }
        }

        public class RemoveUrlStringTests
        {
            [Theory]
            [InlineData("www.codewars.com#about", "www.codewars.com")]
            [InlineData("www.codewars.com/katas/?page=1#about", "www.codewars.com/katas/?page=1")]
            [InlineData("www.codewars.com/katas/", "www.codewars.com/katas/")]
            public void Test(string input, string expected)
            {
                Assert.Equal(expected, RemoveUrlAnchorKata.RemoveUrlAnchor(input));
            }
        }
        
        public class PartsOfAListTests
        {
            [Theory]
            [InlineData(new[] { "cdIw", "tzIy", "xDu", "rThG" },
                "[[cdIw, tzIy xDu rThG], [cdIw tzIy, xDu rThG], [cdIw tzIy xDu, rThG]]")]
            [InlineData(new[] { "I", "wish", "I", "hadn't", "come" },
                "[[I, wish I hadn't come], [I wish, I hadn't come], [I wish I, hadn't come], [I wish I hadn't, come]]")]
            [InlineData(new[] { "vJQ", "anj", "mQDq", "sOZ" },
                "[[vJQ, anj mQDq sOZ], [vJQ anj, mQDq sOZ], [vJQ anj mQDq, sOZ]]")]
            public void RetrievesPartsOfAList(string[] input, string expected)
            {
                Assert.Equal(expected, Convert2DArrayToString(PartList.Partlist(input)));
            }

            private string Convert2DArrayToString(string[][] arr)
            {
                var sb = new StringBuilder();

                foreach (string[] row in arr)
                {
                    sb.Append("[")
                      .Append(string.Join(' ', row))
                      .Append("]");
                }

                return sb.ToString();
            }
        }

        

    }
}
