using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class BaseTiefling : IRace
    {
        protected Dictionary<string, int> BaseTieflingASI = new Dictionary<string, int>()
        {
            {"CHA", 2},
            {"INT", 1}
        };
        protected string BaseTieflingSize = "Medium";
        protected int BaseTieflingSpeed = 30;
        protected HashSet<string> BaseTieflingLanguages = new HashSet<string>()
        {
            "Common",
            "Infernal"
        };
        protected bool BaseTieflingDarkvision = true;
        protected HashSet<string> BaseTieflingProficiencies = new HashSet<string>();
    }

    class Tiefling : BaseTiefling
    {
        public Tiefling()
        {
            _raceName = "Tiefling";
            _raceScoreBuff = new Dictionary<string, int>(BaseTieflingASI);
            _raceSize = BaseTieflingSize;
            _raceSpeed = BaseTieflingSpeed;
            _raceLanguages = BaseTieflingLanguages;
            _darkvision = BaseTieflingDarkvision;
            _raceProficiencies = new HashSet<string>(BaseTieflingProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
