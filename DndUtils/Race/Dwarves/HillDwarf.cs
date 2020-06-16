using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class HillDwarf : Dwarf
    {
        public HillDwarf()
        {
            _raceName = "Hill Dwarf";
            _raceScoreBuff = new Dictionary<string, int>(BaseDwarfASI)
            {
                { "WIS", 1}
            };
            _raceSize = BaseDwarfSize;
            _raceSpeed = BaseDwarfSpeed;
            _raceLanguages = BaseDwarfLanguages;
            _darkvision = BaseDwarfDarkvision;
            _raceProficiencies = new HashSet<string>(BaseDwarfProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
