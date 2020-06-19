using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class Halfling : IRace
    {
        protected Dictionary<string, int> BaseHalflingASI = new Dictionary<string, int>()
        {
            {"DEX", 2}
        };
        protected string BaseHalflingSize = "Small";
        protected int BaseHalflingSpeed = 25;
        protected HashSet<string> BaseHalflingLanguages = new HashSet<string>() 
        { 
            "Common", 
            "Halfling" 
        };
        protected bool BaseHalflingDarkvision = false;
        protected HashSet<string> BaseHalflingProficiencies = new HashSet<string>();
    }

    class StoutHalfling : Halfling
    {
        public StoutHalfling()
        {
            _raceName = "Stout Halfling";
            _raceScoreBuff = new Dictionary<string, int>(BaseHalflingASI)
            {
                {"CON", 1}
            };
            _raceSize = BaseHalflingSize;
            _raceSpeed = BaseHalflingSpeed;
            _raceLanguages = BaseHalflingLanguages;
            _darkvision = BaseHalflingDarkvision;
            _raceProficiencies = new HashSet<string>(BaseHalflingProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }

    class LightfootHalfling : Halfling
    {
        public LightfootHalfling()
        {
            _raceName = "Lightfoot Halfling";
            _raceScoreBuff = new Dictionary<string, int>(BaseHalflingASI)
            {
                {"CHA", 1}
            };
            _raceSize = BaseHalflingSize;
            _raceSpeed = BaseHalflingSpeed;
            _raceLanguages = BaseHalflingLanguages;
            _darkvision = BaseHalflingDarkvision;
            _raceProficiencies = new HashSet<string>(BaseHalflingProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
