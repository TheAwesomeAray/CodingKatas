namespace CodingKatas.SteveSmith
{
    public class RPGCombat
    {
        public class Character
        {
            public bool Alive { get; private set; } = true;
            public int Health { get; private set; } = 1000;
            public int Level { get; private set; } = 1;

            public void Attack(Character target)
            {
                target.Health -= 200;

                if (target.Health <= 0)
                    target.Alive = false;
            }

            public void Heal(Character target)
            {
                if (target.Health + 200 > 1000)
                    target.Health = 1000;
                else
                    target.Health += 200;
            }
        }

    }
}
