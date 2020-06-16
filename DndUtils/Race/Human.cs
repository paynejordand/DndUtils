using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class Human : IRace
    {
        protected Dictionary<string, int> BaseHumanASI = new Dictionary<string, int>()
        {
            {"STR", 1},
            {"DEX", 1},
            {"CON", 1},
            {"INT", 1},
            {"WIS", 1},
            {"CHA", 1},
        };
        protected string BaseHumanSize = "Medium";
        protected int BaseHumanSpeed = 30;
        protected HashSet<string> BaseHumanLanguages = new HashSet<string>()
        {
            "Common"
        };
        protected bool BaseHumanDarkvision = false;
        protected HashSet<string> BaseHumanProficiencies = new HashSet<string>();
    }
}
