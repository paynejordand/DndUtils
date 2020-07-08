using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator.Race
{
    class BaseDwarf : IRace
    {
        protected Dictionary<string, int> BaseDwarfASI = new Dictionary<string, int>()
        {
            {"CON", 2}
        };
        protected string BaseDwarfSize = "Medium";
        protected int BaseDwarfSpeed = 25;
        protected HashSet<string> BaseDwarfLanguages = new HashSet<string>() { "Common", "Dwarvish" };
        protected bool BaseDwarfDarkvision = true;
        protected HashSet<string> BaseDwarfProficiencies = new HashSet<string>() { "Battleaxe", "Handaxe", "Throwing hammer", "Warhammer" };
    }

    class MountainDwarf : BaseDwarf
    {
        public MountainDwarf()
        {
            _raceName = "Mountain Dwarf";
            _raceScoreBuff = new Dictionary<string, int>(BaseDwarfASI)
            {
                {"STR", 2}
            };
            _raceSize = BaseDwarfSize;
            _raceSpeed = BaseDwarfSpeed;
            _raceLanguages = BaseDwarfLanguages;
            _darkvision = BaseDwarfDarkvision;
            _raceProficiencies = new HashSet<string>(BaseDwarfProficiencies)
            {
                "Light armor",
                "Heavy armor"
            };
            _sourceBook = "Player's Handbook";
        }
    }

    class HillDwarf : BaseDwarf
    {
        public HillDwarf()
        {
            _raceName = "Hill Dwarf";
            _raceScoreBuff = new Dictionary<string, int>(BaseDwarfASI)
            {
                { "WIS", 1}
            };
            _raceSize = BaseDwarfSize;
            _raceSpeed = BaseDwarfSpeed;
            _raceLanguages = BaseDwarfLanguages;
            _darkvision = BaseDwarfDarkvision;
            _raceProficiencies = new HashSet<string>(BaseDwarfProficiencies);
            _sourceBook = "Player's Handbook";
        }
    }
}
