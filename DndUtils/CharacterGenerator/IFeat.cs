using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DndUtils.CharacterGenerator
{
    class IFeat
    {
        private static HashSet<string> SpellCastingClasses = new HashSet<string>
        {
            "Bard",
            "Cleric",
            "Druid",
            "Paladin",
            "Ranger",
            "Sorcerer",
            "Warlock",
            "Wizard",
        };

        public static List<Type> allFeats = new List<Type>(typeof(IFeat).Assembly.DefinedTypes.Where(x => typeof(IFeat).IsAssignableFrom(x) && x != typeof(IFeat)).ToList());
        public static IFeat FactoryMethod(string pFeat)
        {
            var types = typeof(IFeat).Assembly.DefinedTypes.Where(x => typeof(IFeat).IsAssignableFrom(x) && x != typeof(IFeat));
            foreach (var x in types)
            {
                if (x.Name.Equals(pFeat))
                    return (IFeat)Activator.CreateInstance(x);
            }
            return new IFeat();
        }

        public string FeatName { get; }
        public string FeatDescription { get; }

        public static HashSet<string> FeatProficiencyPreReq { get; }
        public static HashSet<string> FeatAbilityScorePreReq { get; }
        public static HashSet<string> FeatSpellCastingPreReq { get; }
        
        public HashSet<string> FeatAbilityScoreEffect { get; }
        public int FeatSpeedEffect { get; }
        public int FeatHealthEffect { get; }
    }
}
