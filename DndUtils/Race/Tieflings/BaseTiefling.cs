using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class BaseTiefling : Tiefling
    {
        public BaseTiefling()
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
