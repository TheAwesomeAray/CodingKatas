using CodingKatas;
using Xunit;

namespace CodingKataTests
{
    public class KataTests
    {
        [Fact]
        public void DescendingOrder()
        {
            Assert.Equal(54321, DescendingOrderKata.DescendingOrder(12345));
            Assert.Equal(54321, DescendingOrderKataSolution.DescendingOrder(12345));
        }
    }
}
