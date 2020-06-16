using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class BaseDragonborn : Dragonborn
    {
        public BaseDragonborn()
        {
            _raceName = "Dragonborn";
            _raceScoreBuff = new Dictionary<string, int>(BaseDragonbornASI);
            _raceSize = BaseDragonbornSize;
            _raceSpeed = BaseDragonbornSpeed;
            _raceLanguages = BaseDragonbornLanguages;
            _darkvision = BaseDragonbornDarkvision;
            _raceProficiencies = new HashSet<string>(BaseDragonbornProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
