using FluentAssertions;
using Xunit;

namespace CodingKatas.SteveSmith
{
    public class ZombieSurvivorsTests
    {
        [Fact]
        public void Survivor_WhenReceivedTwoWounds_AliveIsFalse()
        {
            var survivor = new Survivor();

            survivor.Wound();
            survivor.Wound();

            survivor.Alive.Should().BeFalse();
        }
    }
}
