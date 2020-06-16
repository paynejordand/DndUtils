using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
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
}
