using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
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
