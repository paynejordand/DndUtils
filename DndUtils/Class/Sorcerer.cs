using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
            _classSkillsOptions = new Dictionary<int, HashSet<string>>()
            {
                {
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
