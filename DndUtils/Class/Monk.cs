using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
    class Monk : IClass
    {
        public Monk()
        {
            _className = "Monk";
            _classAbilityOrder = new List<string>()
            {
                "DEX", 
                "WIS", 
                "CON", 
                "CHA", 
                "INT", 
                "STR"
            };
            _classHitDie = 8;
            _classProficiencies = new HashSet<string>()
            {
                "Simple weapons",
                "Shortsword"
            };
            _classSavingThrows = new HashSet<string>()
            {
                "STR",
                "DEX"
            };
            _classSkillsOptions = new KeyValuePair<int, HashSet<string>>
            (
                2,
                new HashSet<string>()
                {
                    "Acrobatics",
                    "Athletics",
                    "History",
                    "Insight",
                    "Religion",
                    "Stealth"
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
