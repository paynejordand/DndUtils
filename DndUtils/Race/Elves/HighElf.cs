using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class HighElf : Elf
    {
        public HighElf()
        {
            _raceName = "High Elf";
            _raceScoreBuff = new Dictionary<string, int>(BaseElfASI)
            {
                { "INT", 1}
            };
            _raceSize = BaseElfSize;
            _raceSpeed = BaseElfSpeed;
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
