using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DndUtils.CharacterGenerator
{
    class IFeat
    {
        protected static HashSet<string> SpellCastingClasses = new HashSet<string>
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

        protected string _featName;
        public string FeatName 
        { 
            get => _featName; 
        }
        protected string _featDescription;
        public string FeatDescription 
        { 
            get => _featDescription;
        }
        protected HashSet<string> _featProficiencyPreReq;
        public HashSet<string> FeatProficiencyPreReq 
        { 
            get => _featProficiencyPreReq;
        }
        protected HashSet<string> _featAbilityScorePreReq;
        public HashSet<string> FeatAbilityScorePreReq 
        { 
            get => _featAbilityScorePreReq;
        }
        protected HashSet<string> _featSpellCastingPreReq;
        public HashSet<string> FeatClassPreReq 
        { 
            get => _featSpellCastingPreReq;
        }
        protected HashSet<string> _featAbilityScoreEffect;
        public HashSet<string> FeatAbilityScoreEffect 
        { 
            get => _featAbilityScoreEffect;
        }
        protected HashSet<string> _featProficiencyEffect;
        public HashSet<string> FeatProficiencyEffect
        {
            get => _featProficiencyEffect;
        }

        public override string ToString()
        {
            string output = $"{FeatName}\n" +
                $"\t{FeatDescription}\n" +
                $"PreReqs: \n" +
                $"\tProficiencies:\n";
            foreach (string prof in FeatProficiencyPreReq)
                output += $"\t\t{prof}";
            output += $"\tAbility Scores (13+):\n";
            foreach (string ability in FeatAbilityScorePreReq)
                output += $"\t\t{ability}\n";
            output += $"\tRequired Class:\n";
            foreach (string _class in FeatClassPreReq)
                output += $"\t\t{_class}\n";
            output += $"Effects:\n" +
                $"\tAbility Score Increase Options:\n";
            foreach (string ability in FeatAbilityScoreEffect)
                output += $"\t\t{ability}\n";
            return output;
        }
    }

    class Alert : IFeat
    {
        public Alert()
        {
            _featName = "Alert";
            _featDescription =
                "Always on the lookout for danger you gain the following benefits:\n" +
                "\t- You gain a +5 bonus to initiative.\n" +
                "\t- You can't be surprised while you are conscious.\n" +
                "\t- Other creatures don't gain advantage on attack rolls against you as a result of being hidden from you.\n";
            _featProficiencyPreReq = new HashSet<string>();
            _featAbilityScorePreReq = new HashSet<string>();
            _featSpellCastingPreReq = new HashSet<string>();
            _featAbilityScoreEffect = new HashSet<string>();
            _featProficiencyEffect = new HashSet<string>();
        }

        public override string ToString()
        {
            string output = $"{FeatName}\n" +
                $"\t{FeatDescription}\n";
            return output;
        }
    }
}
