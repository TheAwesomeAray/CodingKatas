using FluentAssertions;
using Xunit;
using static CodingKatas.SteveSmith.RPGCombat;

namespace CodingKatas.SteveSmith
{
    public class RPGCombatTests
    {
        [Fact]
        public void Character_CreatedWithAppropriateDefaultValues()
        {
            var character = new Character();

            character.Health.Should().Be(1000);
            character.Alive.Should().Be(true);
            character.Level.Should().Be(1);
        }

        [Fact]
        public void Attack_DamagesTargetCharacter()
        {
            var attackingCharacter = new Character();
            var targetCharacter = new Character();

            attackingCharacter.Attack(targetCharacter);

            targetCharacter.Health.Should().Be(800);
        }

        [Fact]
        public void Heal_IncreasesHealthOfTargetCharacter()
        {
            var healingCharacter = new Character();
            var targetCharacter = new Character();
            healingCharacter.Attack(targetCharacter);
            
            healingCharacter.Heal(targetCharacter);

            targetCharacter.Health.Should().Be(1000);
        }

        [Fact]
        public void Heal_CannotRaiseHealthAbove1000()
        {
            var healingCharacter = new Character();
            var targetCharacter = new Character();

            healingCharacter.Heal(targetCharacter);

            targetCharacter.Health.Should().Be(1000);
        }

        [Fact]
        public void Character_WhenReducedAtOrBelow0Health_AliveIsFalse()
        {
            var attackingCharacter = new Character();
            var targetCharacter = new Character();

            attackingCharacter.Attack(targetCharacter);
            attackingCharacter.Attack(targetCharacter);
            attackingCharacter.Attack(targetCharacter);
            attackingCharacter.Attack(targetCharacter);
            attackingCharacter.Attack(targetCharacter);

            targetCharacter.Alive.Should().Be(false);
        }
    }
}
