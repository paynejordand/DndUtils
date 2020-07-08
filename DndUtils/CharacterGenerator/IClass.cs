using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;


namespace DndUtils.CharacterGenerator.Class
{
    class IClass
    {
        public static List<Type> allClasses = new List<Type>(typeof(IClass).Assembly.DefinedTypes.Where(x => typeof(IClass).IsAssignableFrom(x) && x != typeof(IClass)).ToList());
        public static IClass FactoryMethod(string pClass)
        {
            var types = typeof(IClass).Assembly.DefinedTypes.Where(x => typeof(IClass).IsAssignableFrom(x) && x != typeof(IClass));
            foreach (var x in types)
            {
                if (x.Name.Equals(pClass))
                    return (IClass)Activator.CreateInstance(x);
            }
            return new IClass();
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

    class Barbarian : IClass
    {
        public Barbarian()
        {
            _className = "Barbarian";
            _classAbilityOrder = new List<string>
            {
                "STR",
                "CON",
                "DEX",
                "WIS",
                "CHA",
                "INT"
            };
            _classHitDie = 12;
            _classProficiencies = new HashSet<string>()
            {
                "Light armor",
                "Medium armor",
                "Shields",
                "Simple weapons",
                "Martial weapons"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "STR",
                "CON"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "Animal Handling",
                    "Athletics",
                    "Intimidation",
                    "Nature",
                    "Perception",
                    "Survival"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Bard : IClass
    {
        public Bard()
        {
            _className = "Bard";
            _classAbilityOrder = new List<string>()
            {
                "CHA",
                "DEX",
                "CON",
                "WIS",
                "STR",
                "INT"
            };
            _classHitDie = 8;
            _classProficiencies = new HashSet<string>()
            {
                "Light armor",
                "Simple weapons",
                "Hand crossbow",
                "Longsword",
                "Rapier",
                "Shortsword"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "DEX",
                "CHA"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                3,
                new HashSet<string>()
                {
                    "Acrobatics",
                    "Animal Handling",
                    "Arcana",
                    "Athletics",
                    "Deception",
                    "History",
                    "Insight",
                    "Intimidation",
                    "Investigation",
                    "Medicine",
                    "Nature",
                    "Perception",
                    "Performance",
                    "Persuasion",
                    "Religion",
                    "Sleight of Hand",
                    "Stealth",
                    "Survival"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Cleric : IClass
    {
        public Cleric()
        {
            _className = "Cleric";
            _classAbilityOrder = new List<string>()
            {
                "WIS",
                "STR",
                "CON",
                "CHA",
                "DEX",
                "INT"
            };
            _classHitDie = 8;
            _classProficiencies = new HashSet<string>()
            {
                "Light armor",
                "Medium armor",
                "Shields",
                "Simple weapons"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "WIS",
                "CHA"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "History",
                    "Insight",
                    "Medicine",
                    "Persuasion",
                    "Religion"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Druid : IClass
    {
        public Druid()
        {
            _className = "Druid";
            _classAbilityOrder = new List<string>()
            {
                "WIS",
                "CON",
                "DEX",
                "INT",
                "STR",
                "CHA"
            };
            _classHitDie = 8;
            _classProficiencies = new HashSet<string>()
            {
                "Light armor",
                "Medium armor",
                "Shields",
                "Clubs",
                "Daggers",
                "Darts",
                "Javelins",
                "Maces",
                "Quarterstaffs",
                "Scimitars",
                "Sickles",
                "Slings",
                "Spears",
                "Herbalism Kit"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "INT",
                "WIS"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "Arcana",
                    "Animal Handling",
                    "Insight",
                    "Medicine",
                    "Nature",
                    "Perception",
                    "Religion",
                    "Survival"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Fighter : IClass
    {
        public Fighter()
        {
            _className = "Fighter";
            _classAbilityOrder = new List<string>()
            {
                "STR",
                "CON",
                "WIS",
                "INT",
                "DEX",
                "CHA"
            };
            _classHitDie = 10;
            _classProficiencies = new HashSet<string>()
            {
                "Light armor",
                "Medium armor",
                "Heavy armor",
                "Shields",
                "Simple weapons",
                "Martial weapons"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "STR",
                "CON"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "Acrobatics",
                    "Animal Handling",
                    "Athletics",
                    "History",
                    "Insight",
                    "Intimidation",
                    "Perception",
                    "Survival"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                14,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Monk : IClass
    {
        public Monk()
        {
            _className = "Monk";
            _classAbilityOrder = new List<string>()
            {
                "DEX",
                "WIS",
                "CON",
                "CHA",
                "INT",
                "STR"
            };
            _classHitDie = 8;
            _classProficiencies = new HashSet<string>()
            {
                "Simple weapons",
                "Shortsword"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "STR",
                "DEX"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "Acrobatics",
                    "Athletics",
                    "History",
                    "Insight",
                    "Religion",
                    "Stealth"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Paladin : IClass
    {
        public Paladin()
        {
            _className = "Paladin";
            _classAbilityOrder = new List<string>()
            {
                "STR",
                "CHA",
                "CON",
                "WIS",
                "INT",
                "DEX"
            };
            _classHitDie = 10;
            _classProficiencies = new HashSet<string>()
            {
                "Light armor",
                "Medium armor",
                "Heavy armor",
                "Shields",
                "Simple weapons",
                "Martial weapons"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "WIS",
                "CHA"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "Athletics",
                    "Insight",
                    "Intimidation",
                    "Medicine",
                    "Persuasion",
                    "Religion"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Ranger : IClass
    {
        public Ranger()
        {
            _className = "Ranger";
            _classAbilityOrder = new List<string>()
            {
                "DEX",
                "CON",
                "WIS",
                "INT",
                "STR",
                "CHA"
            };
            _classHitDie = 10;
            _classProficiencies = new HashSet<string>()
            {
                "Light armor",
                "Medium armor",
                "Shields",
                "Simple weapons",
                "Martial weapons"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "STR",
                "DEX"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                3,
                new HashSet<string>()
                {
                    "Animal Handling",
                    "Athletics",
                    "Insight",
                    "Investigation",
                    "Nature",
                    "Perception",
                    "Stealth",
                    "Survival"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Rogue : IClass
    {
        public Rogue()
        {
            _className = "Rogue";
            _classAbilityOrder = new List<string>()
            {
                "DEX",
                "CHA",
                "WIS",
                "CON",
                "INT",
                "STR"
            };
            _classHitDie = 8;
            _classProficiencies = new HashSet<string>()
            {
                "Light armor",
                "Simple weapons",
                "Hand crossbow",
                "Longsword",
                "Rapier",
                "Shortsword",
                "Thieves' Tools"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "DEX",
                "INT"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                4,
                new HashSet<string>()
                {
                    "Acrobatics",
                    "Athletics",
                    "Deception",
                    "Insight",
                    "Intimidation",
                    "Investigation",
                    "Perception",
                    "Performance",
                    "Persuasion",
                    "Sleight of Hand",
                    "Stealth"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                10,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Sorcerer : IClass
    {
        public Sorcerer()
        {
            _className = "Sorcerer";
            _classAbilityOrder = new List<string>()
            {
                "CHA",
                "CON",
                "DEX",
                "INT",
                "WIS",
                "STR"
            };
            _classHitDie = 6;
            _classProficiencies = new HashSet<string>()
            {
                "Daggers",
                "Darts",
                "Slings",
                "Quarterstaffs",
                "Light crossbows"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "CON",
                "CHA"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "Arcana",
                    "Deception",
                    "Insight",
                    "Intimidation",
                    "Persuasion",
                    "Religion"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Warlock : IClass
    {
        public Warlock()
        {
            _className = "Warlock";
            _classAbilityOrder = new List<string>()
            {
                "CHA",
                "CON",
                "DEX",
                "INT",
                "WIS",
                "STR"
            };
            _classHitDie = 8;
            _classProficiencies = new HashSet<string>()
            {
                "Light armor",
                "Simple Weapons"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "WIS",
                "CHA"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "Arcana",
                    "Deception",
                    "History",
                    "Intimidation",
                    "Investigation",
                    "Nature",
                    "Religion"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class Wizard : IClass
    {
        public Wizard()
        {
            _className = "Wizard";
            _classAbilityOrder = new List<string>()
            {
                "INT",
                "CON",
                "CHA",
                "WIS",
                "DEX",
                "STR"
            };
            _classHitDie = 6;
            _classProficiencies = new HashSet<string>()
            {
                "Daggers",
                "Darts",
                "Slings",
                "Quarterstaffs",
                "Light crossbows"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "INT",
                "WIS"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "Arcana",
                    "History",
                    "Insight",
                    "Investigation",
                    "Medicine",
                    "Religion"
                }
            );
            _classASILevels = new HashSet<int>()
            {
                4,
                8,
                12,
                16,
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }
}
