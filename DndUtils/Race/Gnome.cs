using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.Race
{
    class Gnome : IRace
    {
        protected Dictionary<string, int> BaseGnomeASI = new Dictionary<string, int>()
        {
            {"INT", 2}
        };
        protected string BaseGnomeSize = "Small";
        protected int BaseGnomeSpeed = 25;
        protected HashSet<string> BaseGnomeLanguages = new HashSet<string>()
        {
            "Common",
            "Gnomish"
        };
        protected bool BaseGnomeDarkvision = true;
        protected HashSet<string> BaseGnomeProficiencies = new HashSet<string>();
    }
}
