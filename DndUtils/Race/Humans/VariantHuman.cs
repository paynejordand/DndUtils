using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class VariantHuman : Human
    {
        public VariantHuman()
        {
            _raceName = "Variant Human";
            _raceScoreBuff = new Dictionary<string, int>();
            _raceSize = BaseHumanSize;
            _raceSpeed = BaseHumanSpeed;
            _raceLanguages = BaseHumanLanguages;
            _darkvision = BaseHumanDarkvision;
            _raceProficiencies = BaseHumanProficiencies;
            _sourceBook = "Player's Handbook";
        }
    }
}
