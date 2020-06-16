using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
            _classSkillsOptions = new Dictionary<int, HashSet<string>>()
            {
                {
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
