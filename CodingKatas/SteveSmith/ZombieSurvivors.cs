using System;
using System.Collections.Generic;

namespace CodingKatas.SteveSmith
{
    public class Survivor
    {
        private int MaxEquipment { get; set; } = 5;

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

        private List<Equipment> _equipment { get; set; } = new List<Equipment>();
        public IReadOnlyList<Equipment> Equipment => _equipment.AsReadOnly();

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

        internal void Equip(Equipment equipment)
        {
            if (Equipment.Count == MaxEquipment)
                throw new InvalidOperationException();

            _equipment.Add(equipment);
        }
    }

    public class Equipment
    { }

}
