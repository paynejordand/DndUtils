using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class BaseHalfOrc : HalfOrc
    {
        public BaseHalfOrc()
        {
            _raceName = "Half-Orc";
            _raceScoreBuff = new Dictionary<string, int>(BaseHalfOrcASI);
            _raceSize = BaseHalfOrcSize;
            _raceSpeed = BaseHalfOrcSpeed;
            _raceLanguages = BaseHalfOrcLanguages;
            _darkvision = BaseHalfOrcDarkvision;
            _raceProficiencies = new HashSet<string>(BaseHalfOrcProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
