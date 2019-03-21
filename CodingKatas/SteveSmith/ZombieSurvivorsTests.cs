using FluentAssertions;
using System;
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

        [Fact]
        public void Survivor_WoundsCannotExceed2()
        {
            var survivor = new Survivor();

            survivor.Wound();
            survivor.Wound();
            survivor.Wound();

            survivor.Wounds.Should().Be(2);
        }

        [Fact]
        public void Survivor_CanPerformThreeActionsPerTurn()
        {
            var survivor = new Survivor();

            survivor.PerformAction();
            survivor.PerformAction();
            survivor.PerformAction();

            Action action = () => survivor.PerformAction();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Survivor_EndOfTurn_ActionsAreReset()
        {
            var survivor = new Survivor();

            survivor.PerformAction();
            survivor.PerformAction();
            survivor.PerformAction();

            survivor.EndOfTurn();

            survivor.ActionsPerformed.Should().Be(0);

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
