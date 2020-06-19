using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class Dragonborn : IRace
    {
        protected Dictionary<string, int> BaseDragonbornASI = new Dictionary<string, int>()
        {
            {"STR", 2},
            {"CHA", 1}
        };
        protected string BaseDragonbornSize = "Medium";
        protected int BaseDragonbornSpeed = 30;
        protected HashSet<string> BaseDragonbornLanguages = new HashSet<string>()
        {
            "Common",
            "Draconic"
        };
        protected bool BaseDragonbornDarkvision = false;
        protected HashSet<string> BaseDragonbornProficiencies = new HashSet<string>();
    }

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
