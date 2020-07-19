using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace DndUtils.CharacterGenerator.Race
{
    class IRace
    {
        public static List<Type> allRaces = new List<Type>(typeof(IRace).Assembly.DefinedTypes.Where(x => typeof(IRace).IsAssignableFrom(x) && x != typeof(IRace) && x.BaseType != typeof(IRace)).ToList()); 
        public static IRace FactoryMethod(string pRace)
        {
            var t = typeof(IRace).Assembly.DefinedTypes.Where(x => typeof(IRace).IsAssignableFrom(x) && x != typeof(IRace)).ToList();
            var types = typeof(IRace).Assembly.DefinedTypes.Where(x => typeof(IRace).IsAssignableFrom(x) && x != typeof(IRace));
            foreach (var x in types)
            {
                if (x.Name.Equals(pRace))
                    return (IRace)Activator.CreateInstance(x);
            }
            return new IRace();
        }

        protected string _raceName;
        public string RaceName
        {
            get => _raceName;
        }

        protected Dictionary<string, int> _raceScoreBuff = new Dictionary<string, int>();
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

        protected HashSet<string> _raceLanguages = new HashSet<string>();
        public HashSet<string> RaceLanguages
        {
            get => _raceLanguages;
        }

        protected bool _darkvision;
        public bool Darkvision
        {
            get => _darkvision;
        }

        protected HashSet<string> _raceProficiencies = new HashSet<string>();
        public HashSet<string> RaceProficiencies
        {
            get => _raceProficiencies;
        }

        protected string _sourceBook = "Player's Handbook";
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
