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
    }
}
