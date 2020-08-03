using DndUtils.CharacterGenerator.Race;
using DndUtils.CharacterGenerator.Class;
using DndUtils.CharacterGenerator.Feat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections;

namespace DndUtils.CharacterGenerator
{
    class CharacterController
    {
        private readonly CharacterModel model;

        public static readonly HashSet<string> allLanguages = new HashSet<string> { "Common", "Dwarvish", "Elvish", "Giant", "Gnomish",
                           "Goblin", "Halfling", "Orc", "Abyssal", "Celestial",
                           "Draconic", "Deep Speech", "Infernal", "Primordial",
                           "Sylvan", "Undercommon"};

        public static readonly HashSet<string> artisanTools = new HashSet<string> { "Smith's Tools", "Brewer's Supplies",
                           "Mason's Tools"};

        public static readonly HashSet<string> allSkills = new HashSet<string> { "Acrobatics", "Animal Handling", "Arcana",
                    "Athletics", "Deception", "History", "Insight",
                    "Intimidation", "Investigation", "Medicine", "Nature",
                    "Perception", "Performance", "Persuasion", "Religion",
                    "Sleight of Hand", "Stealth", "Survival"};


        public CharacterController()
        {
            this.model = new CharacterModel();
        }

        public IRace GetRace()
        {
            return model.PlayerRace;
        }

        public IClass GetClass()
        {
            return model.PlayerClass;
        }

        public int GetPlayerLevel()
        {
            return model.PlayerLevel;
        }

        public string GetPlayerName()
        {
            return model.PlayerName;
        }

        public void SetNameAndLevel(string name, int level)
        {
            model.PlayerName = name;
            model.PlayerLevel = level;
        }

        public void SetRaceAndClass(IRace race, IClass _class)
        {
            model.PlayerRace = race;
            model.PlayerClass = _class;
        }

        public HashSet<string> GetProficiencies()
        {
            return model.PlayerProficiencies;
        }

        public void AddProficiency(string prof)
        {
            this.model.PlayerProficiencies.Add(prof);
        }

        public void AddProficiency(IEnumerable<string> profs)
        {
            this.model.PlayerProficiencies.UnionWith(profs);
        }

        public Dictionary<string, int> GetStats()
        {
            return model.PlayerAbilityScore;
        }

        public Dictionary<string, int> GetAbilityMods()
        {
            return model.PlayerAbilityModifier;
        }

        public int GetStat(string stat)
        {
            return model.PlayerAbilityScore[stat];
        }

        public int GetStatMod(string stat)
        {
            return model.PlayerAbilityModifier[stat];
        }

        public int GetSpeed()
        {
            return model.PlayerSpeed;
        }

        public int GetHealth()
        {
            return model.PlayerTotalHealth;
        }

        public HashSet<IFeat> GetFeats()
        {
            return model.PlayerFeats;
        }

        public HashSet<string> GetLanguages()
        {
            return model.PlayerLanguages;
        }

        public void SetStats(Dictionary<string, int> stats)
        {
            model.PlayerAbilityScore = stats;
        }

        public void AddFeat(string feat)
        {
            IFeat tFeat = IFeat.FactoryMethod(feat);
            model.PlayerFeats.Add(tFeat);

            if (tFeat.FeatProficiencyEffect.Count > 0)
                model.PlayerProficiencies.UnionWith(tFeat.FeatProficiencyEffect);
        }

        public void AddFeat(IEnumerable<string> feats)
        {
            foreach (string feat in feats)
                AddFeat(feat);
        }

        public override string ToString()
        {
            return model.ToString();
        }

        public void RollStats()
        {
            Dictionary<string, int> baseStats = new Dictionary<string, int>();
            List<int> statRoll = DiceRoller.RollStats();
            for(int i = 0; i < 6; i++)
            {
                baseStats.Add(model.PlayerClass.ClassAbilityOrder[i], statRoll[i]);
            }

            foreach(KeyValuePair<string, int> kv in model.PlayerRace.RaceScoreBuff)
            {
                baseStats[kv.Key] += kv.Value;
            }

            model.PlayerAbilityScore = baseStats;
        }

        public int GreaterLevel()
        {
            int ASICount = 0;
            do
            {
                model.PlayerLeveling++;
                model.PlayerRolledHealth += RollHitDie();
                if (model.PlayerClass.ClassASILevels.Contains(model.PlayerLeveling))
                {
                    ASICount++;
                }
                    
            } while (model.PlayerLeveling < model.PlayerLevel);

            return ASICount;
        }

        private int RollHitDie()
        {
            int health = DiceRoller.RollDie(model.PlayerClass.ClassHitDie);
            while (health == 1)
                health = DiceRoller.RollDie(model.PlayerClass.ClassHitDie);

            return health;
        }

        public void AbilityIncrease(string pAbility)
        {
            model.PlayerAbilityScore[pAbility] += 1;
        }

        public List<string> FeatOptions()
        {
            List<string> featOptions = new List<string>();
            foreach (var t in IFeat.allFeats)
            {
                bool ProfPreReq = true;
                bool ASPreReq = true;
                bool ClassPreReq = true;
                IFeat temp = IFeat.FactoryMethod(t.Name);
                if (temp.FeatProficiencyPreReq.Count > 0)
                {
                    ProfPreReq = false;
                    foreach (string prof in temp.FeatProficiencyPreReq)
                    {
                        if (model.PlayerProficiencies.Contains(prof))
                        {
                            ProfPreReq = true;
                            break;
                        }
                    }
                }
                if (temp.FeatAbilityScorePreReq.Count > 0)
                {
                    ASPreReq = false;
                    foreach (string ability in temp.FeatAbilityScorePreReq)
                    {
                        if (model.PlayerAbilityScore[ability] >= 13)
                        {
                            ASPreReq = true;
                            break;
                        }
                    }
                }
                if (temp.FeatClassPreReq.Count > 0)
                {
                    ClassPreReq = false;
                    if (temp.FeatClassPreReq.Contains(model.PlayerClass.ClassName))
                        ClassPreReq = true;
                }

                if (ProfPreReq && ASPreReq && ClassPreReq && !model.PlayerFeats.Any(x => x.FeatName == temp.FeatName))
                    featOptions.Add(t.Name);
            }
            return featOptions;
        }

        // The code below here rolls a random character. There's probably a better way to do it but for now I'm gonna leave it.

        public void RandomCharacter(int level, string name)
        {
            model.PlayerName = name;
            IRace pRace = RandomRace();
            model.PlayerRace = pRace;
            RandomRaceSpecifics();
            IClass pClass = RandomClass();
            model.PlayerClass = pClass;
            RandomClassSpecifics();
            RollStats();
            model.PlayerLevel = level;
            int ASICount = 0;
            if (model.PlayerLevel > 1)
                ASICount = GreaterLevel();
            for (int i = 0; i < ASICount; i++)
                RandomSpecialLevel();
        }

        private IRace RandomRace()
        {
            var random = new Random();
            int index = random.Next(IRace.allRaces.Count);
            return IRace.FactoryMethod(IRace.allRaces[index].Name);
        }

        private IClass RandomClass()
        {
            var random = new Random();
            int index = random.Next(IClass.allClasses.Count);
            return IClass.FactoryMethod(IClass.allClasses[index].Name);
        }

        private void RandomRaceSpecifics()
        {
            var random = new Random();

            if (model.PlayerRace is BaseDwarf)
            {
                int index = random.Next(artisanTools.Count);
                model.PlayerProficiencies.Add(artisanTools.ElementAt(index));
            }
            else if (model.PlayerRace is HighElf || model.PlayerRace is BaseHuman)
            {
                HashSet<string> pLanguageOptions = new HashSet<string>(allLanguages);
                pLanguageOptions.ExceptWith(model.PlayerLanguages);
                int index = random.Next(pLanguageOptions.Count);
                model.PlayerLanguages.Add(pLanguageOptions.ElementAt(index));
            }
            else if (model.PlayerRace is HalfElf)
            {
                HashSet<string> pSkillOptions = new HashSet<string>(allSkills);
                pSkillOptions.ExceptWith(model.PlayerProficiencies);

                int index = random.Next(pSkillOptions.Count);
                string pSkill = pSkillOptions.ElementAt(index);
                model.PlayerProficiencies.Add(pSkill);
                pSkillOptions.Remove(pSkill);

                index = random.Next(pSkillOptions.Count);
                pSkill = pSkillOptions.ElementAt(index);
                model.PlayerProficiencies.Add(pSkill);

                HashSet<string> pLanguageOptions = new HashSet<string>(allLanguages);
                pLanguageOptions.ExceptWith(model.PlayerLanguages);
                index = random.Next(pLanguageOptions.Count);
                model.PlayerLanguages.Add(pLanguageOptions.ElementAt(index));
            }
        }

        private void RandomClassSpecifics()
        {
            var random = new Random();
            HashSet<string> pSkillOptions = new HashSet<string>(model.PlayerClass.ClassSkillsOptions.Value);
            pSkillOptions.ExceptWith(model.PlayerProficiencies);
            for (int i = model.PlayerClass.ClassSkillsOptions.Key; i > 0; i--)
            {
                int index = random.Next(pSkillOptions.Count);
                string pSkill = pSkillOptions.ElementAt(index);
                model.PlayerProficiencies.Add(pSkill);
                pSkillOptions.Remove(pSkill);
            }
        }

        private void RandomSpecialLevel()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (KeyValuePair<string, int> kv in model.PlayerAbilityScore)
                {
                    if (kv.Value < 20) 
                    {
                        AbilityIncrease(kv.Key);
                        break;
                    }
                }
            }
        }
    }
}
