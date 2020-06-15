using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class WoodElf : Elf
    {
        public WoodElf()
        {
            _raceName = "Wood Elf";
            _raceScoreBuff = new Dictionary<string, int>(BaseElfASI)
            {
                { "WIS", 1}
            };
            _raceSize = BaseElfSize;
            _raceSpeed = 35;
            _raceLanguages = BaseElfLanguages;
            _darkvision = BaseElfDarkvision;
            _raceProficiencies = new HashSet<string>(BaseElfProficiencies)
            {
                "Longsword",
                "Shortsword",
                "Shortbow",
                "Longbow"
            };
            _sourceBook = "Player's Handbook";
        }
    }
}
