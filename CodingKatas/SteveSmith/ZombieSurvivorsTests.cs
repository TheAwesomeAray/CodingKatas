using FluentAssertions;
using System;
using Xunit;

namespace CodingKatas.SteveSmith
{
    public class ZombieSurvivorsTests
    {
        public class GeneralTests
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
            }
        }

        public class EquipmentTests
        {
            [Fact]
            public void Survivor_CanCarry5PiecesOfEquipment()
            {
                var survivor = new Survivor();
                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());

                Action action = () => survivor.Equip(new Equipment());

                action.Should().Throw<InvalidOperationException>();
            }
        }
    }
}
