using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
            _classSkillsOptions = new Dictionary<int, HashSet<string>>()
            {
                {
                    2,
                    new HashSet<string>()
                    {
                        "History",
                        "Insight",
                        "Medicine",
                        "Persuasion",
                        "Religion"
                    }
                }
            };
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
