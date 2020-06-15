using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class HillDwarf : IRace
    {
        public HillDwarf()
        {
            _raceName = "Hill Dwarf";
            _raceScoreBuff = new Dictionary<string, int>()
            {
                {"CON", 2 },
                {"WIS", 1 }
            };
            _raceSize = "Medium";
            _raceSpeed = 25;
            _raceLanguages = new HashSet<string>() { "Common", "Dwarvish" };
            _darkvision = true;
            _raceProficiencies = new HashSet<string>() { "Battleaxe", "Handaxe", "Throwing hammer", "Warhammer" };
        }
    }
}
