using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class Gnome : IRace
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

    class RockGnome : Gnome
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
            _sourceBook = "Player's Handbook";
        }
    }

    class ForestGnome : Gnome
    {
        public ForestGnome()
        {
            _raceName = "Forest Gnome";
            _raceScoreBuff = new Dictionary<string, int>(BaseGnomeASI)
            {
                {"DEX", 1}
            };
            _raceSize = BaseGnomeSize;
            _raceSpeed = BaseGnomeSpeed;
            _raceLanguages = BaseGnomeLanguages;
            _darkvision = BaseGnomeDarkvision;
            _raceProficiencies = new HashSet<string>(BaseGnomeProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
