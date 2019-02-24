using FluentAssertions;
using Xunit;

namespace CodingKatas
{
    public class EscapeTests
    {
        [Theory]
        [InlineData("\t1234", "\\t1234")]
        [InlineData("1234\t", "1234\\t")]
        [InlineData("12\t34", "12\\t34")]
        [InlineData("\t\t\t", "\\t\\t\\t")]
        public void Escape_ConvertsTabEscapeSequenceToVisibleEscapeSequence(string input, string expected)
        {
            var s = new char[6];
            new EscapeKata().Escape(s, input.ToCharArray());

            s.Should().Equal(expected.ToCharArray());
        }

        [Theory]
        [InlineData("\n1234", "\\n1234")]
        [InlineData("1234\n", "1234\\n")]
        [InlineData("12\n34", "12\\n34")]
        [InlineData("\n\n\n", "\\n\\n\\n")]
        public void Escape_ConvertsNewlineEscapeSequenceToVisibleEscapeSequence(string input, string expected)
        {
            var s = new char[6];
            new EscapeKata().Escape(s, input.ToCharArray());

            s.Should().Equal(expected.ToCharArray());
        }
    }
}
