using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
}
