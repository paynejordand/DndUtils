using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class Dwarf : IRace
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
}
