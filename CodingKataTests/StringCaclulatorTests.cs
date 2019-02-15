using CodingKatas;
using System;
using Xunit;

namespace CodingKataTests
{
    public class StringCaclulatorTests
    {
        [Fact]
        public void Add_EmptyString_Returns0()
        {
            var actual = new StringCalculator().Add("");

            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("5", 5)]
        [InlineData("10", 10)]
        [InlineData("32", 32)]
        [InlineData("572", 572)]
        public void Add_OneNumber_ReturnsThatNumber(string input, int expected)
        {
            var actual = new StringCalculator().Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("5, 10, 15", 30)]
        [InlineData("5, 10", 15)]
        public void Add_MultipleNumbersSeparatedByComma_ReturnsSum(string input, int expected)
        {
            var actual = new StringCalculator().Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1\n2\n3", 6)]
        [InlineData("5\n10\n15", 30)]
        [InlineData("32\n10", 42)]
        public void Add_MultipleNumbersSeparatedByNewLine_ReturnsSum(string input, int expected)
        {
            var actual = new StringCalculator().Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2\n3", 6)]
        [InlineData("5\n10,15", 30)]
        [InlineData("56\n10,15", 81)]
        public void Add_MultipleNumbersSeparatedByNewLineOrComma_ReturnsSum(string input, int expected)
        {
            var actual = new StringCalculator().Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//;\n1;2;3", 6)]
        [InlineData("//;\n5;10;15", 30)]
        [InlineData("//;\n15;10;15", 40)]
        public void Add_DelimeterProvided_ReturnsSum(string input, int expected)
        {
            var actual = new StringCalculator().Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("-10")]
        [InlineData("-1")]
        [InlineData("-90")]
        [InlineData("-1,-2")]
        [InlineData("-1\n-2")]
        public void Add_NegativeNumber_ThrowsException(string input)
        {
            Assert.Throws<Exception>(() => new StringCalculator().Add(input));
        }

    }
}
