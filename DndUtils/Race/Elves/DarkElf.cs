using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class DarkElf : Elf
    {
        public DarkElf()
        {
            _raceName = "Dark Elf";
            _raceScoreBuff = new Dictionary<string, int>(BaseElfASI)
            {
                { "CHA", 1}
            };
            _raceSize = BaseElfSize;
            _raceSpeed = BaseElfSpeed;
            _raceLanguages = BaseElfLanguages;
            _darkvision = BaseElfDarkvision;
            _raceProficiencies = new HashSet<string>(BaseElfProficiencies)
            {
                "Rapier",
                "Shortsword",
                "Hand crossbow"
            };
            _sourceBook = "Player's Handbook";
        }
    }
}
