using CodingKatas;
using Xunit;

namespace CodingKatas
{
    public class FizzBuzzTests
    {
        public class UsingFizzBuzzTranslator
        {
            [Theory]
            [InlineData(new int[] { }, "")]
            [InlineData(new[] { 1 }, "1")]
            [InlineData(new[] { 1, 2, 4, 7 }, "1\n2\n4\n7")]
            [InlineData(new[] { 97, 98, 101 }, "97\n98\n101")]
            public void Translate_GivenInputIsNotDivisibleByThreeOrFive_ReturnsSameInput(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzTranslator().Translate(input));
            }

            [Theory]
            [InlineData(new[] { 3, 6, 9, 12, 99, 102 }, "Fizz\nFizz\nFizz\nFizz\nFizz\nFizz")]
            public void Translate_GivenInputIsDivibleByThree_ReturnsFizz(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzTranslator().Translate(input));
            }

            [Theory]
            [InlineData(new[] { 5, 10, 20, 100, 110 }, "Buzz\nBuzz\nBuzz\nBuzz\nBuzz")]
            public void Translate_GivenInputIsDivibleByFive_ReturnsBuzz(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzTranslator().Translate(input));
            }

            [Theory]
            [InlineData(new[] { 15, 30, 45, 90, 450 }, "FizzBuzz\nFizzBuzz\nFizzBuzz\nFizzBuzz\nFizzBuzz")]
            public void Translate_GivenInputIsDivibleByFiveAndThree_ReturnsFizzBuzz(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzTranslator().Translate(input));
            }

            [Theory]
            [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 },
                "1\n2\nFizz\n4\nBuzz\nFizz\n7\n8\nFizz\nBuzz\n11\nFizz\n13\n14\nFizzBuzz")]
            public void Translate_ReturnsCorrectResultForCombinedSetOfRules(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzTranslator().Translate(input));
            }
        }

        public class UsingFizzBuzzExtraCreditTranslator
        {
            [Theory]
            [InlineData(new int[] { }, "")]
            [InlineData(new[] { 1 }, "1")]
            [InlineData(new[] { 1, 2, 4, 6, 7, 8, 9 }, "1\n2\n4\n6\n7\n8\n9")]
            [InlineData(new[] { 97, 98, 99, 100, 101, 102 }, "97\n98\n99\n100\n101\n102")]
            public void Translate_GivenInputIsNotDivisibleByThreeOrFive_ReturnsSameInput(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzExtraCreditTranslator().Translate(input));
            }

            [Theory]
            [InlineData(new[] { 3, 13, 23, 33, 43, 403 }, "Fizz\nFizz\nFizz\nFizz\nFizz\nFizz")]
            public void Translate_GivenInputContainsThree_ReturnsFizz(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzExtraCreditTranslator().Translate(input));
            }

            [Theory]
            [InlineData(new[] { 5, 15, 25, 45, 55, 605 }, "Buzz\nBuzz\nBuzz\nBuzz\nBuzz\nBuzz")]
            public void Translate_GivenInputContainsFive_ReturnsBuzz(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzExtraCreditTranslator().Translate(input));
            }

            [Theory]
            [InlineData(new[] { 35, 53, 305, 503 }, "FizzBuzz\nFizzBuzz\nFizzBuzz\nFizzBuzz")]
            public void Translate_GivenInputContainsThreeAndFive_ReturnsFizzBuzz(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzExtraCreditTranslator().Translate(input));
            }

            [Theory]
            [InlineData(new[] { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 },
                "21\n22\nFizz\n24\nBuzz\n26\n27\n28\n29\nFizz\nFizz\nFizz\nFizz\nFizz\nFizzBuzz")]
            public void Translate_ReturnsCorrectResultForCombinedSetOfRules(int[] input, string expected)
            {
                Assert.Equal(expected, new FizzBuzzExtraCreditTranslator().Translate(input));
            }
        }
    }
}
