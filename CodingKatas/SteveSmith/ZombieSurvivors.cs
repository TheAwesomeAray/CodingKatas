using System;
using System.Collections.Generic;
using System.Text;

namespace CodingKatas.SteveSmith
{
    public class Survivor
    {
        public int Wounds { get; set; }

        public bool Alive { get; set; }

        internal void Wound()
        {
            Wounds++;
            if (Wounds >= 2)
                Alive = false;
        }
    }
}
