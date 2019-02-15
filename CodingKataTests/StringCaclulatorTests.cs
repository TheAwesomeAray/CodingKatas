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
    }
}
