using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingKatas.SteveSmith
{
    public class Survivor
    {
        public readonly string Name;
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
        public int Experience { get; private set; }

        private List<Equipment> _equipment { get; set; } = new List<Equipment>();
        public IReadOnlyList<Equipment> Equipment => _equipment.AsReadOnly();

        public Survivor(string name)
        {
            Name = name;
        }

        public Survivor()
        { }

        internal void Wound()
        {
            Wounds++;
            MaxEquipment--;
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

        internal void Ready(Equipment equipmentToReady)
        {
            if (MaximumReadyCapacityExceeded(equipmentToReady))
                throw new InvalidOperationException();
            equipmentToReady.Status = EquipmentStatus.Readied;
        }

        private bool MaximumReadyCapacityExceeded(Equipment equipmentToReady)
        {
            return Equipment.Where(x => x.Status == EquipmentStatus.Readied).Count() >= 2 &&
                                        equipmentToReady.Status != EquipmentStatus.Readied;
                                        

        }

        public void Kill()
        {
            GainExperience(1);
        }

        private void GainExperience(int experience)
        {
            Experience += 1;
        }
    }

    public class Equipment
    {
        public EquipmentStatus Status { get; internal set; } = EquipmentStatus.InBag;
    }

    public enum EquipmentStatus
    {
        InBag = 1,
        Readied = 2
    }

    public enum Level
    {
        Blue = 1,
        Yellow,
        Orange,
        Red
    }

    public class Game
    {
        private List<Survivor> _survivors { get; set; } = new List<Survivor>();
        public IReadOnlyList<Survivor> Survivors => _survivors.AsReadOnly();
        private GameState State { get; set; } = GameState.InProgress;
        public void AddSurvivor(Survivor survivor)
        {
            if (Survivors.Select(x => x.Name).Contains(survivor.Name))
                throw new InvalidOperationException();

            _survivors.Add(survivor);
        }

        public GameState GetState()
        {
            if (!_survivors.Where(x => x.Alive).Any() && State != GameState.Over)
                State = GameState.Over;

            return State;
        }
    }

    public enum GameState
    {
        InProgress = 1,
        Over = 2
    }

}
