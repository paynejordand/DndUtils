using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
                    "Aracana",
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
