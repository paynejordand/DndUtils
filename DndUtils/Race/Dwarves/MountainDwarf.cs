using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class MountainDwarf : Dwarf
    {
        public MountainDwarf()
        {
            _raceName = "Mountain Dwarf";
            _raceScoreBuff = new Dictionary<string, int>(BaseDwarfASI)
            {
                {"STR", 2}
            };
            _raceSize = BaseDwarfSize;
            _raceSpeed = BaseDwarfSpeed;
            _raceLanguages = BaseDwarfLanguages;
            _darkvision = BaseDwarfDarkvision;
            _raceProficiencies = new HashSet<string>(BaseDwarfProficiencies)
            {
                "Light armor",
                "Heavy armor"
            };
            _sourceBook = "Player's Handbook";
        }
    }
}
