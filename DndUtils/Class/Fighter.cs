using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
            _classSkillsOptions = new Dictionary<int, HashSet<string>>()
            {
                {
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
                }
            };
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
}
