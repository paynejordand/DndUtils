using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class Elf : IRace
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

    class DarkElf : Elf
    {
        public DarkElf()
        {
            _raceName = "Dark Elf";
            _raceScoreBuff = new Dictionary<string, int>(BaseElfASI)
            {
                { "CHA", 1}
            };
            _raceSize = BaseElfSize;
            _raceSpeed = BaseElfSpeed;
            _raceLanguages = BaseElfLanguages;
            _darkvision = BaseElfDarkvision;
            _raceProficiencies = new HashSet<string>(BaseElfProficiencies)
            {
                "Rapier",
                "Shortsword",
                "Hand crossbow"
            };
            _sourceBook = "Player's Handbook";
        }
    }

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
