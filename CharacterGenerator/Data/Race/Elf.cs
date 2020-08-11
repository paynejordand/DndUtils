using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class BaseElf : IRace
    {
        protected Dictionary<string, int> BaseElfASI = new Dictionary<string, int>()
        {
            {"DEX", 2}
        };
        protected string BaseElfSize = "Medium";
        protected int BaseElfSpeed = 30;
        protected HashSet<string> BaseElfLanguages = new HashSet<string>() 
        { 
            "Common", 
            "Elvish"
        };
        protected bool BaseElfDarkvision = true;
        protected HashSet<string> BaseElfProficiencies = new HashSet<string>() 
        { 
            "Perception"
        };
    }

    class HighElf : BaseElf
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
        }
    }
}
