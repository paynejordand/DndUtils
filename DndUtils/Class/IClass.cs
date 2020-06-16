using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
    class IClass
    {
        public static HashSet<string> allClasses = new HashSet<string> { "Barbarian", "Bard", "Cleric", "Druid", "Fighter",
                    "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer",
                    "Warlock", "Wizard"};

        public static IClass FactoryMethod(string pClass)
        {
            return pClass switch
            {
                "Barbarian" => new Barbarian(),
                "Bard" => new Bard(),
                "Cleric" => new Cleric(),
                "Druid" => new Druid(),
                "Fighter" => new Fighter(),
                "Monk" => new Monk(),
                "Paladin" => new Paladin(),
                "Ranger" => new Ranger(),
                "Rogue" => new Rogue(),
                "Sorcerer" => new Sorcerer(),
                "Warlock" => new Warlock(),
                "Wizard" => new Wizard(),
                _ => new IClass(),
            };
        }

        protected string _className;
        public string ClassName
        {
            get => _className;
        }
        protected List<string> _classAbilityOrder;
        public List<string> ClassAbilityOrder
        {
            get => _classAbilityOrder;
        }

        protected int _classHitDie;
        public int ClassHitDie
        {
            get => _classHitDie;
        }

        protected HashSet<string> _classProficiencies;
        public HashSet<string> ClassProficiencies
        {
            get => _classProficiencies;
        }

        protected HashSet<string> _classSavingThrows;
        public HashSet<string> ClassSavingThrows
        {
            get => _classSavingThrows;
        }

        protected KeyValuePair<int, HashSet<string>> _classSkillsOptions;
        public KeyValuePair<int, HashSet<string>> ClassSkillsOptions
        {
            get => _classSkillsOptions;
        }

        protected HashSet<int> _classASILevels;
        public HashSet<int> ClassASILevels
        {
            get => _classASILevels;
        }

        protected string _sourceBook;
        public string SourceBook
        {
            get => _sourceBook;
        }

        public override string ToString()
        {
            string output = $"Name: {ClassName}\n" +
                $"Ability Preference: \n";
            foreach (string s in ClassAbilityOrder)
                output += $"\t {s}\n";
            output += $"Hit Die: {ClassHitDie}\n" +
                $"Proficiencies: \n";
            foreach (string s in ClassProficiencies)
                output += $"\t {s}\n";
            output += $"Saving throws: \n";
            foreach (string s in ClassSavingThrows)
                output += $"\t {s}\n";
            output += $"Skill Options: \n" +
                $"\t Choose {ClassSkillsOptions.Key}:\n";
            foreach (string s in ClassSkillsOptions.Value)
                    output += $"\t\t {s}\n";
            output += $"Ability Score Increase at Levels: \n";
            foreach (int i in ClassASILevels)
                output += $"\t{i} \n";
            output += $"Source: {SourceBook}\n\n";
            return output;
        }
    }
}
