using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class HalfElf : IRace
    {
        protected Dictionary<string, int> BaseHalfElfASI = new Dictionary<string, int>()
        {
            {"CHA", 2}
        };
        protected string BaseHalfElfSize = "Medium";
        protected int BaseHalfElfSpeed = 30;
        protected HashSet<string> BaseHalfElfLanguages = new HashSet<string>()
        {
            "Common",
            "Elvish"
        };
        protected bool BaseHalfElfDarkvision = true;
        protected HashSet<string> BaseHalfElfProficiencies = new HashSet<string>();
    }
}
