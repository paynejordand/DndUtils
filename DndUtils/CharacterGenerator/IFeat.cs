using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DndUtils.CharacterGenerator.Feat
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

        protected string _featName = "Default Name";
        public string FeatName 
        { 
            get => _featName; 
        }
        protected string _featDescription = "Default Description";
        public string FeatDescription 
        { 
            get => _featDescription;
        }
        protected HashSet<string> _featProficiencyPreReq = new HashSet<string>();
        public HashSet<string> FeatProficiencyPreReq 
        { 
            get => _featProficiencyPreReq;
        }
        protected HashSet<string> _featAbilityScorePreReq = new HashSet<string>();
        public HashSet<string> FeatAbilityScorePreReq 
        { 
            get => _featAbilityScorePreReq;
        }
        protected HashSet<string> _featClassPreReq = new HashSet<string>();
        public HashSet<string> FeatClassPreReq 
        { 
            get => _featClassPreReq;
        }
        protected HashSet<string> _featAbilityScoreEffect = new HashSet<string>();
        public HashSet<string> FeatAbilityScoreEffect 
        { 
            get => _featAbilityScoreEffect;
        }
        protected HashSet<string> _featProficiencyEffect = new HashSet<string>();
        public HashSet<string> FeatProficiencyEffect
        {
            get => _featProficiencyEffect;
        }

        protected bool _featExtraEffects = false;
        public bool FeatExtraEffects
        {
            get => _featExtraEffects;
        }

        public virtual void FeatApplyExtraEffects(CharacterModel model, CharacterView view) { }

        public override string ToString()
        {
            string output = $"{FeatName}\n" +
                $"{FeatDescription}\n";
            if(FeatProficiencyPreReq.Count > 0 || FeatAbilityScorePreReq.Count > 0 || FeatClassPreReq.Count > 0)
            {
                output += $"PreReqs: \n";
                if(FeatProficiencyPreReq.Count > 0)
                {
                    output += $"\tProficiencies:\n";
                    foreach (string prof in FeatProficiencyPreReq)
                        output += $"\t\t{prof}\n";
                }
                if(FeatAbilityScorePreReq.Count > 0)
                {
                    output += $"\tAbility Scores (13+):\n";
                    foreach (string ability in FeatAbilityScorePreReq)
                        output += $"\t\t{ability}\n";
                }
                if(FeatClassPreReq.Count > 0)
                {
                    output += $"\tRequired Class:\n";
                    foreach (string _class in FeatClassPreReq)
                        output += $"\t\t{_class}\n";
                }
            }
            if(FeatAbilityScoreEffect.Count > 0 || FeatProficiencyEffect.Count > 0)
            {
                output += $"Effects:\n";
                if(FeatAbilityScoreEffect.Count > 0)
                {
                    output += $"\tAbility Score Increase Options:\n";
                    foreach (string ability in FeatAbilityScoreEffect)
                        output += $"\t\t{ability}\n";
                }
                if(FeatProficiencyEffect.Count > 0)
                {
                    output += $"\tAdded Proficiencies:\n";
                    foreach (string prof in FeatProficiencyEffect)
                        output += $"\t\t{prof}\n";
                }
            }
            return output;
        }
    }

    class Grappler : IFeat
    {
        public Grappler()
        {
            _featName = "Grappler";
            _featDescription =
                "Prerequisite: Strength 13 or higher.\n" +
                "You've developed the skills necessary to hold your own in close-quarters grappling. You gain the following benefits:\n" +
                "\t- You have advantage on attack rolls against a creature you are grappling.\n" +
                "\t- You can use your action to try to pin a creature grappled by you. To do so, make another grapple check. If you succeed, you " +
                "and the creature are both restrained until the grapple ends.\n" +
                "\t- Creatures that are one size larger than you don't automatically succeed on checks to escape your grapple.\n";
            _featAbilityScorePreReq = new HashSet<string>()
            {
                "STR",
            };
        }
    }
}
