using CodingKatas;
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
    }
}
