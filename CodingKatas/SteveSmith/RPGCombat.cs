using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingKatas.SteveSmith
{
    public class RPGCombat
    {
        public class Character
        {
            public bool Alive { get; internal set; } = true;
            public int Health { get; private set; } = 1000;
            public int Level { get; private set; } = 1;

            public void LevelUp(int increaseAmount)
            {
                Level += increaseAmount;
            }

            private List<AttackStatusRule> Rules = new List<AttackStatusRule>()
            {
                new DeathStatusRule(),
                new LevelModifierStatusRule(),
                new SelfDamageStatusRule()
            };

            public void Attack(Character target)
            {
                var attack = new AttackEvent(200, this);
                
                target.Defend(attack);
            }

            private  void Defend(AttackEvent attack)
            {
                foreach (var rules in Rules.OrderBy(x => x.Priority))
                    rules.ApplyRule(attack, this);

                Health -= attack.Damage;
            }

            public void Heal(Character target)
            {
                if (!target.Alive || !Equals(target))
                    return;

                if (target.Health + 200 > 1000)
                    target.Health = 1000;
                else
                    target.Health += 200;
            }
        }

        public interface AttackStatusRule
        {
            int Priority { get; }
            void ApplyRule(AttackEvent attack, Character target);
        }

        public class DeathStatusRule : AttackStatusRule
        {
            public int Priority => 2;

            public void ApplyRule(AttackEvent attack, Character target)
            {
                if (target.Health - attack.Damage <= 0)
                    target.Alive = false;
            }
        }

        public class LevelModifierStatusRule : AttackStatusRule
        {
            public int Priority => 1;

            public void ApplyRule(AttackEvent attack, Character target)
            {
                if (attack.Attacker.Level - target.Level >= 5)
                    attack.Damage += (int)(attack.Damage * .5);
                else if (attack.Attacker.Level - target.Level <= -5)
                    attack.Damage -= (int)(attack.Damage * .5);
            }
        }

        public class SelfDamageStatusRule : AttackStatusRule
        {
            public int Priority => 0;

            public void ApplyRule(AttackEvent attack, Character target)
            {
                if (attack.Attacker.Equals(target))
                    attack.Damage = 0;
            }
        }




        public class AttackEvent
        {
            public readonly Character Attacker;
            public int Damage { get; internal set; }

            public AttackEvent(int damage, Character attacker)
            {
                Attacker = attacker;
                Damage = damage;
            }
        }

    }
}
