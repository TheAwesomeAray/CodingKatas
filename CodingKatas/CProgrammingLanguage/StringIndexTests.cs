using FluentAssertions;
using Xunit;

namespace CodingKatas.CProgrammingLanguage
{
    public class StringIndexTests
    {
        [Theory]
        [InlineData("12345", "3", 2)]
        [InlineData("12345", "34", 2)]
        [InlineData("The quick brown fox", "brown", 10)]
        public void StringIndex_ReturnsIndexOfString(string input, string searchTerm, int expected)
        {
            new StringIndexKata().StringIndex(input, searchTerm).Should().Be(expected);
        }

        [Theory]
        [InlineData("32345", "3", 2)]
        [InlineData("342345", "34", 3)]
        [InlineData("test quick test fox", "test", 11)]
        public void StringIndex_ReturnsRightmostIndexOfString(string input, string searchTerm, int expected)
        {
            new StringIndexKata().StringIndex(input, searchTerm).Should().Be(expected);
        }

        [Theory]
        [InlineData("32345", "6")]
        [InlineData("342345", "9")]
        [InlineData("test quick test fox", "test2")]
        public void StringIndex_ReturnsNegativeOneIfNoMatchFound(string input, string searchTerm)
        {
            new StringIndexKata().StringIndex(input, searchTerm).Should().Be(-1);
        }
    }
}
