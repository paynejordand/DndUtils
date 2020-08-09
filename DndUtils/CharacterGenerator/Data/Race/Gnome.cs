using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class BaseGnome : IRace
    {
        protected Dictionary<string, int> BaseGnomeASI = new Dictionary<string, int>()
        {
            {"INT", 2}
        };
        protected string BaseGnomeSize = "Small";
        protected int BaseGnomeSpeed = 25;
        protected HashSet<string> BaseGnomeLanguages = new HashSet<string>()
        {
            "Common",
            "Gnomish"
        };
        protected bool BaseGnomeDarkvision = true;
        protected HashSet<string> BaseGnomeProficiencies = new HashSet<string>();
    }

    class RockGnome : BaseGnome
    {
        public RockGnome()
        {
            _raceName = "Rock Gnome";
            _raceScoreBuff = new Dictionary<string, int>(BaseGnomeASI)
            {
                {"CON", 1}
            };
            _raceSize = BaseGnomeSize;
            _raceSpeed = BaseGnomeSpeed;
            _raceLanguages = BaseGnomeLanguages;
            _darkvision = BaseGnomeDarkvision;
            _raceProficiencies = new HashSet<string>(BaseGnomeProficiencies)
            {
                "Tinker's tools"
            };
        }
    }
}
