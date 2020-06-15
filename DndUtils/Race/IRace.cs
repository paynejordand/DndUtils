using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class IRace
    {
        public static HashSet<string> allRaces = new HashSet<string> { "Hill Dwarf", "Mountain Dwarf", "High Elf",
                    "Wood Elf", "Dark Elf", "Lightfoot Halfling",
                    "Stout Halfling", "Human", "Dragonborn", "Forest Gnome",
                    "Rock Gnome", "Half Elf", "Half Orc", "Tiefling"};

        public static HashSet<string> allAttributes = new HashSet<string> { "INT", "CHA", "WIS", "DEX", "CON", "STR"};

        public static HashSet<string> allLanguages = new HashSet<string> { "Common", "Dwarvish", "Elvish", "Giant", "Gnomish",
                           "Goblin", "Halfling", "Orc", "Abyssal", "Celestial",
                           "Draconic", "Deep Speech", "Infernal", "Primordial",
                           "Sylvan", "Undercommon"};

        public static HashSet<string> artisanTools = new HashSet<string> { "Smith's Tools", "Brewer's Supplies",
                           "Mason's Tools"};


        protected string _raceName;
        public string RaceName
        {
            get => _raceName;
        }

        protected Dictionary<string, int> _raceScoreBuff;
        public Dictionary<string, int> RaceScoreBuff
        {
            get => _raceScoreBuff;
        }

        protected string _raceSize;
        public string RaceSize
        {
            get => _raceSize;
        }

        protected int _raceSpeed;
        public int RaceSpeed
        {
            get => _raceSpeed;
        }

        protected HashSet<string> _raceLanguages;
        public HashSet<string> RaceLanguages
        {
            get => _raceLanguages;
        }

        protected bool _darkvision;
        public bool Darkvision
        {
            get => _darkvision;
        }

        protected HashSet<string> _raceProficiencies;
        public HashSet<string> RaceProficiencies
        {
            get => _raceProficiencies;
        }

        protected string _sourceBook;
        public string SourceBook
        {
            get => _sourceBook;
        }
    }
}
