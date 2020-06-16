using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
}
