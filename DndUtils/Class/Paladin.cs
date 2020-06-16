using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
}
