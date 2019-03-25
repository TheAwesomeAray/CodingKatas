using FluentAssertions;
using System;
using System.Linq;
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

            [Fact]
            public void Survivor_Kill_Gains1Experience()
            {
                var survivor = new Survivor();

                survivor.Kill();

                survivor.Experience.Should().Be(1);
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

            [Fact]
            public void Survivor_CanCarryEquipment()
            {
                var survivor = new Survivor();

                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());

                survivor.Equipment.Count.Should().Be(3);
            }

            [Fact]
            public void Survivor_CanReadyEquipment()
            {
                var survivor = new Survivor();
                var equipmentToReady = new Equipment();
                survivor.Equip(equipmentToReady);
                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());

                survivor.Ready(equipmentToReady);

                equipmentToReady.Status = EquipmentStatus.Readied;
            }

            [Fact]
            public void Survivor_CanReadyMaximumofTwoPiecesOfEquipment()
            {
                var survivor = new Survivor();
                var equipmentToReady1 = new Equipment();
                var equipmentToReady2 = new Equipment();
                var equipmentToReady3 = new Equipment();
                survivor.Equip(equipmentToReady1);
                survivor.Equip(equipmentToReady2);
                survivor.Equip(equipmentToReady3);
                survivor.Ready(equipmentToReady1);
                survivor.Ready(equipmentToReady2);
                

                Action action = () => survivor.Ready(equipmentToReady3);

                action.Should().Throw<InvalidOperationException>();
            }

            [Fact]
            public void Survivor_ReadyingEquipmentAlreadyInReadiedStateDoesNothing()
            {
                var survivor = new Survivor();
                var equipmentToReady = new Equipment();
                survivor.Equip(equipmentToReady);
                survivor.Ready(equipmentToReady);
                survivor.Ready(equipmentToReady);
                survivor.Ready(equipmentToReady);
                survivor.Ready(equipmentToReady);

                survivor.Equipment.Single().Status.Should().Be(EquipmentStatus.Readied);
            }

            [Fact]
            public void Survivor_WoundsReduceCarryingCapacityBy1()
            {
                var survivor = new Survivor();
                survivor.Wound();
                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());
                survivor.Equip(new Equipment());

                Action action = () => survivor.Equip(new Equipment());

                action.Should().Throw<InvalidOperationException>();
            }
        }

        public class GameTests
        {
            [Fact]
            public void AddSurvivor_SurvivorAddedToGame()
            {
                var game = new Game();

                var survivor = new Survivor("Bob");
                game.AddSurvivor(survivor);

                game.Survivors.Count().Should().Be(1);
            }
            
            [Fact]
            public void AddSurvivor_SurvivorNameIsNotUnique_ThrowsInvalidOperationException()
            {
                var game = new Game();

                var survivor = new Survivor("Bob");
                var survivor2 = new Survivor("Bob");
                game.AddSurvivor(survivor);
                Action action = () => game.AddSurvivor(survivor2);

                action.Should().Throw<InvalidOperationException>();
            }

            [Fact]
            public void Game_Ends_WhenAllSurvivorsAreDead()
            {
                var game = new Game();
                var survivor = new Survivor();
                game.AddSurvivor(survivor);

                survivor.Wound();
                survivor.Wound();

                game.GetState().Should().Be(GameState.Over);
            }
        }
    }
}
