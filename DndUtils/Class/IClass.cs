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
        public static HashSet<string> allSkills = new HashSet<string> { "Acrobatics", "Animal Handling", "Arcana",
                    "Athletics", "Deception", "History", "Insight",
                    "Intimidation", "Investigation", "Medicine", "Nature",
                    "Perception", "Performance", "Persuasion", "Religion",
                    "Sleight of Hand", "Stealth", "Survival"};


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
