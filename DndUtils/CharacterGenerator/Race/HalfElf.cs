using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class BaseHalfElf : IRace
    {
        protected Dictionary<string, int> BaseHalfElfASI = new Dictionary<string, int>()
        {
            {"CHA", 2}
        };
        protected string BaseHalfElfSize = "Medium";
        protected int BaseHalfElfSpeed = 30;
        protected HashSet<string> BaseHalfElfLanguages = new HashSet<string>()
        {
            "Common",
            "Elvish"
        };
        protected bool BaseHalfElfDarkvision = true;
        protected HashSet<string> BaseHalfElfProficiencies = new HashSet<string>();
    }

    class HalfElf : BaseHalfElf
    {
        public HalfElf()
        {
            _raceName = "Half-Elf";
            _raceScoreBuff = new Dictionary<string, int>(BaseHalfElfASI);
            _raceSize = BaseHalfElfSize;
            _raceSpeed = BaseHalfElfSpeed;
            _raceLanguages = BaseHalfElfLanguages;
            _darkvision = BaseHalfElfDarkvision;
            _raceProficiencies = new HashSet<string>(BaseHalfElfProficiencies);
        }
    }
}
