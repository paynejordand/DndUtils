using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class HalfOrc : IRace
    {
        protected Dictionary<string, int> BaseHalfOrcASI = new Dictionary<string, int>()
        {
            {"STR", 2},
            {"CON", 1}
        };
        protected string BaseHalfOrcSize = "Medium";
        protected int BaseHalfOrcSpeed = 30;
        protected HashSet<string> BaseHalfOrcLanguages = new HashSet<string>()
        {
            "Common",
            "Orc"
        };
        protected bool BaseHalfOrcDarkvision = true;
        protected HashSet<string> BaseHalfOrcProficiencies = new HashSet<string>()
        {
            "Intimidation"
        };
    }

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
