using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class BaseHuman : Human
    {
        public BaseHuman()
        {
            _raceName = "Human";
            _raceScoreBuff = new Dictionary<string, int>(BaseHumanASI);
            _raceSize = BaseHumanSize;
            _raceSpeed = BaseHumanSpeed;
            _raceLanguages = BaseHumanLanguages;
            _darkvision = BaseHumanDarkvision;
            _raceProficiencies = new HashSet<string>(BaseHumanProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
