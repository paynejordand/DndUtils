using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
}
