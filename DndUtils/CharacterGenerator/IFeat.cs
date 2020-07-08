using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator
{
    class IFeat
    {
        public string FeatName { get; }
        public string FeatDescription { get; }

        public HashSet<string> FeatProficiencyPreReq { get; }
        public HashSet<string> FeatAbilityScorePreReq { get; }

        
        public HashSet<string> FeatAbilityScoreEffect { get; }
        public int FeatSpeedEffect { get; }
        public int FeatHealthEffect { get; }
    }
}
