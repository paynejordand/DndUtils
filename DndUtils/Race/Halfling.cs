using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class Halfling : IRace
    {
        protected Dictionary<string, int> BaseHalflingASI = new Dictionary<string, int>()
        {
            {"DEX", 2}
        };
        protected string BaseHalflingSize = "Small";
        protected int BaseHalflingSpeed = 25;
        protected HashSet<string> BaseHalflingLanguages = new HashSet<string>() 
        { 
            "Common", 
            "Halfling" 
        };
        protected bool BaseHalflingDarkvision = false;
        protected HashSet<string> BaseHalflingProficiencies = new HashSet<string>();
    }
}
