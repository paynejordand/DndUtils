using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class LightfootHalfling : Halfling
    {
        public LightfootHalfling()
        {
            _raceName = "Lightfoot Halfling";
            _raceScoreBuff = new Dictionary<string, int>(BaseHalflingASI)
            {
                {"CHA", 1}
            };
            _raceSize = BaseHalflingSize;
            _raceSpeed = BaseHalflingSpeed;
            _raceLanguages = BaseHalflingLanguages;
            _darkvision = BaseHalflingDarkvision;
            _raceProficiencies = new HashSet<string>(BaseHalflingProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
