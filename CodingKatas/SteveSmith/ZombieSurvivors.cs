using System;

namespace CodingKatas.SteveSmith
{
    public class Survivor
    {
        private int _wounds;

        public int Wounds
        {
            get { return _wounds; }
            set
            {
                if (Wounds < 2)
                    _wounds = value;
            }
        }

        public bool Alive { get; private set; }

        public int ActionsPerformed { get; private set; }

        internal void Wound()
        {
            Wounds++;
            if (Wounds >= 2)
                Alive = false;
        }

        public void PerformAction()
        {
            if (ActionsPerformed >= 3)
                throw new InvalidOperationException();

            ActionsPerformed++;
        }

        internal void EndOfTurn()
        {
            ActionsPerformed = 0;
        }
    }
}
