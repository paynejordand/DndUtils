using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class Tiefling : IRace
    {
        protected Dictionary<string, int> BaseTieflingASI = new Dictionary<string, int>()
        {
            {"CHA", 2},
            {"INT", 1}
        };
        protected string BaseTieflingSize = "Medium";
        protected int BaseTieflingSpeed = 30;
        protected HashSet<string> BaseTieflingLanguages = new HashSet<string>()
        {
            "Common",
            "Infernal"
        };
        protected bool BaseTieflingDarkvision = true;
        protected HashSet<string> BaseTieflingProficiencies = new HashSet<string>();
    }
}
