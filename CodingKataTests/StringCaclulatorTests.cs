using CodingKatas;
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
        [InlineData("-10", -10)]
        [InlineData("572", 572)]
        public void Add_OneNumber_ReturnsThatNumber(string input, int expected)
        {
            var actual = new StringCalculator().Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("5, 10, 15", 30)]
        [InlineData("-10, 10", 0)]
        public void Add_MultipleNumbersSeparatedByComma_ReturnsSum(string input, int expected)
        {
            var actual = new StringCalculator().Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1\n2\n3", 6)]
        [InlineData("5\n10\n15", 30)]
        [InlineData("-10\n10", 0)]
        public void Add_MultipleNumbersSeparatedByNewLine_ReturnsSum(string input, int expected)
        {
            var actual = new StringCalculator().Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2\n3", 6)]
        [InlineData("5\n10,15", 30)]
        [InlineData("-10\n10,15", 15)]
        public void Add_MultipleNumbersSeparatedByNewLineOrComma_ReturnsSum(string input, int expected)
        {
            var actual = new StringCalculator().Add(input);

            Assert.Equal(expected, actual);
        }
    }
}
