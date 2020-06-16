using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
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
}
