using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Class
{
    class Barbarian : IClass
    {
        public Barbarian()
        {
            _className = "Barbarian";
            _classAbilityOrder = new List<string>
            {
                "STR",
                "CON",
                "DEX",
                "WIS",
                "CHA",
                "INT"
            };
            _classHitDie = 12;
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
                "CON"
            };
            _classSkillsOptions = new Dictionary<int, HashSet<string>>()
            {
                {
                    2,
                    new HashSet<string>()
                    {
                        "Animal Handling",
                        "Athletics",
                        "Intimidation",
                        "Nature",
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
                16, 
                19
            };
            _sourceBook = "Player's Handbook";
        }
    }
}
