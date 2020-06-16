using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class Elf : IRace
    {
        protected Dictionary<string, int> BaseElfASI = new Dictionary<string, int>()
        {
            {"DEX", 2}
        };
        protected string BaseElfSize = "Medium";
        protected int BaseElfSpeed = 30;
        protected HashSet<string> BaseElfLanguages = new HashSet<string>() 
        { 
            "Common", 
            "Elvish"
        };
        protected bool BaseElfDarkvision = true;
        protected HashSet<string> BaseElfProficiencies = new HashSet<string>() 
        { 
            "Perception"
        };
    }
}
