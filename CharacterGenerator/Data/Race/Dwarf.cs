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
            _raceProficiencies = BaseDwarfProficiencies;
        }
    }
}
