using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class BaseHalfElf : HalfElf
    {
        public BaseHalfElf()
        {
            _raceName = "Half-Elf";
            _raceScoreBuff = new Dictionary<string, int>(BaseHalfElfASI);
            _raceSize = BaseHalfElfSize;
            _raceSpeed = BaseHalfElfSpeed;
            _raceLanguages = BaseHalfElfLanguages;
            _darkvision = BaseHalfElfDarkvision;
            _raceProficiencies = new HashSet<string>(BaseHalfElfProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
