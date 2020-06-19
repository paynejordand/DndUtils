using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class IRace
    {
        public static HashSet<string> allRaces = new HashSet<string> { "Hill Dwarf", "Mountain Dwarf", "High Elf",
                    "Wood Elf", "Dark Elf", "Lightfoot Halfling",
                    "Stout Halfling", "Human", "Dragonborn", "Forest Gnome",
                    "Rock Gnome", "Half Elf", "Half Orc", "Tiefling"};

        public static IRace FactoryMethod(string pRace)
        {
            return pRace switch
            {
                "Hill Dwarf" => new HillDwarf(),
                "Mountain Dwarf" => new MountainDwarf(),
                "High Elf" => new HighElf(),
                "Wood Elf" => new WoodElf(),
                "Dark Elf" => new DarkElf(),
                "Lightfoot Halfling" => new LightfootHalfling(),
                "Stout Halfling" => new StoutHalfling(),
                "Human" => new BaseHuman(),
                "Dragonborn" => new BaseDragonborn(),
                "Forest Gnome" => new ForestGnome(),
                "Rock Gnome" => new RockGnome(),
                "Half Elf" => new BaseHalfElf(),
                "Half Orc" => new BaseHalfOrc(),
                "Tiefling" => new BaseTiefling(),
                _ => new IRace(),
            };
        }

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

        public override string ToString()
        {
            string output = $"Race Name: {RaceName}\n" +
                $"ASI: \n";
            foreach (KeyValuePair<string, int> kv in RaceScoreBuff)
                output += $"\t{kv.Key} : {kv.Value}\n";
            output += $"Size: {RaceSize}\n" +
                $"Speed: {RaceSpeed}\n" +
                $"Darkvision: {Darkvision}\n" +
                $"Proficiencies: \n";
            foreach (string s in RaceProficiencies)
                output += $"\t {s}\n";
            output += $"Languages: \n";
            foreach (string s in RaceLanguages)
                output += $"\t{s}\n";
            output += $"Source: {SourceBook}\n\n";
            return output;
        }
    }
}
