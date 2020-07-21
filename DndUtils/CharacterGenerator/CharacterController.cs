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
        private readonly CharacterView view;
        private bool randomCharacter = false;

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
            this.view = new CharacterView();
        }

        public void RollCharacter()
        {
            ChooseName();
            IRace pRace = ChooseRace();
            model.PlayerRace = pRace;
            RaceSpecifics();
            IClass pClass = ChooseClass();
            model.PlayerClass = pClass;
            ClassSpecifics();

            RollStats();
            ChooseLevel();
            if (model.PlayerLevel > 1)
                GreaterLevel();

            view.PrintLine($"\n\n{model}");
        }

        private void ChooseName()
        {
            view.PrintLine("What is your character's name?");
            model.PlayerName = view.GetLine();
        }

        private IRace ChooseRace()
        {
            view.PrintLine("What race would you like to play?");
            view.PrintOptions(IRace.allRaces);
            string pRace = view.GetLine().Replace(" ", "");
            while (!IRace.allRaces.Any(x => x.Name == pRace))
            {
                view.PrintLine("Selected race must be one of the following:");
                view.PrintOptions(IRace.allRaces);
                pRace = view.GetLine().Replace(" ", "");
            }
            return IRace.FactoryMethod(pRace);
        }

        private IClass ChooseClass()
        {
            view.PrintLine("What class would you like to play?");
            view.PrintOptions(IClass.allClasses);
            string pClass = view.GetLine().Replace(" ", "");
            while (!IClass.allClasses.Any(x => x.Name == pClass))
            {
                view.PrintLine("Choice must be one of the following:");
                view.PrintOptions(IClass.allClasses);
                pClass = view.GetLine().Replace(" ", "");
            }
            return IClass.FactoryMethod(pClass);
        }

        private void RaceSpecifics()
        {
            if (model.PlayerRace is BaseDwarf)
            {
                view.PrintLine("As a dwarf you can choose to have proficiency in one of the following:");
                view.PrintSet(artisanTools);
                string pProf = view.GetLine();
                while (!artisanTools.Contains(pProf))
                {
                    view.PrintLine("Choice must be one of the following");
                    view.PrintSet(artisanTools);
                    pProf = view.GetLine();
                }
                model.PlayerProficiencies.Add(pProf);
            }
            else if (model.PlayerRace is HighElf || model.PlayerRace is BaseHuman)
            {
                HashSet<string> pLanguageOptions = new HashSet<string>(allLanguages);
                pLanguageOptions.ExceptWith(model.PlayerLanguages);
                view.PrintLine($"As a {model.PlayerRace.RaceName} you have access to an extra language");
                view.PrintSet(pLanguageOptions);
                string pLang = view.GetLine();
                while (!pLanguageOptions.Contains(pLang))
                {
                    view.PrintLine("Choice must be one of the following:");
                    view.PrintSet(pLanguageOptions);
                    pLang = view.GetLine();
                }
                model.PlayerLanguages.Add(pLang);
            }
            else if (model.PlayerRace is HalfElf)
            {
                HashSet<string> pSkillOptions = new HashSet<string>(allSkills);
                pSkillOptions.ExceptWith(model.PlayerProficiencies);
                view.PrintLine("As a Half Elf you gain proficiency in two additonal skills. Options are:");
                view.PrintSet(pSkillOptions);
                string pSkill = view.GetLine();
                while (!pSkillOptions.Contains(pSkill))
                {
                    view.PrintLine("Choice must be one of the following:");
                    view.PrintSet(pSkillOptions);
                    pSkill = view.GetLine();
                }
                model.PlayerProficiencies.Add(pSkill);
                pSkillOptions.Remove(pSkill);
                view.PrintLine("Choose one more skill from the list.");
                view.PrintSet(pSkillOptions);
                pSkill = view.GetLine();
                while (!pSkillOptions.Contains(pSkill))
                {
                    view.PrintLine("Choice must be one of the following:");
                    view.PrintSet(pSkillOptions);
                    pSkill = view.GetLine();
                }
                model.PlayerProficiencies.Add(pSkill);

                HashSet<string> pLanguageOptions = new HashSet<string>(allLanguages);
                pLanguageOptions.ExceptWith(model.PlayerLanguages);
                view.PrintLine($"As a Half Elf you have access to an extra language");
                view.PrintSet(pLanguageOptions);
                string pLang = view.GetLine();
                while (!pLanguageOptions.Contains(pLang))
                {
                    view.PrintLine("Choice must be one of the following:");
                    view.PrintSet(pLanguageOptions);
                    pLang = view.GetLine();
                }
                model.PlayerLanguages.Add(pLang);
            }
        }

        private void ClassSpecifics()
        {
            HashSet<string> pSkillOptions = new HashSet<string>(model.PlayerClass.ClassSkillsOptions.Value);
            pSkillOptions.ExceptWith(model.PlayerProficiencies);
            for(int i = model.PlayerClass.ClassSkillsOptions.Key; i > 0; i--)
            {
                view.PrintLine($"{model.PlayerClass.ClassName} has proficiency in {i} of the following:");
                view.PrintSet(pSkillOptions);
                string pSkill = view.GetLine();
                while (!pSkillOptions.Contains(pSkill))
                {
                    view.PrintLine("Choice must be one of the following:");
                    view.PrintSet(pSkillOptions);
                    pSkill = view.GetLine();
                }
                model.PlayerProficiencies.Add(pSkill);
                pSkillOptions.Remove(pSkill);
            }
        }

        private void RollStats()
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

        private void ChooseLevel()
        {
            view.PrintLine("What level would you like your character to be?");
            string pString = view.GetLine();
            int pLevel;
            while (!(int.TryParse(pString, out pLevel) && (pLevel > 0 && pLevel < 21)))
            {
                view.PrintLine("Response must be a number between 1 and 20.");
                pString = view.GetLine();
            }

            model.PlayerLevel = pLevel;
            model.PlayerRolledHealth = model.PlayerClass.ClassHitDie + model.PlayerHealthBonus;
        }

        private void GreaterLevel()
        {
            do
            {
                model.PlayerLeveling++;
                model.PlayerRolledHealth += RollHitDie();
                if (model.PlayerClass.ClassASILevels.Contains(model.PlayerLeveling))
                {
                    if (randomCharacter)
                        RandomSpecialLevel();
                    else
                        SpecialLevel();
                }
                    
            } while (model.PlayerLeveling < model.PlayerLevel);
        }

        private int RollHitDie()
        {
            int health = DiceRoller.RollDie(model.PlayerClass.ClassHitDie);
            while (health == 1)
                health = DiceRoller.RollDie(model.PlayerClass.ClassHitDie);

            return health;
        }

        private void SpecialLevel()
        {
            view.PrintLine("Would you like to take a feat (Feat) or take an ability score increase (ASI)");
            string pChoice = view.GetLine();
            while(pChoice != "Feat" && pChoice != "ASI")
            {
                view.PrintLine("Choice must be Feat or ASI");
                pChoice = view.GetLine();
            }
            if (pChoice.Equals("Feat"))
                AddFeat();
            else if (pChoice.Equals("ASI"))
                ASI();
        }

        private void ASI()
        {
            HashSet<string> pASIOptions = new HashSet<string>();
            foreach(KeyValuePair<string, int> kv in model.PlayerAbilityScore)
            {
                if (kv.Value < 20)
                    pASIOptions.Add(kv.Key);
            }
            for(int i = 0; i < 2; i++)
            {
                view.PrintLine("What ability would you like to increase by 1?");
                view.PrintSet(pASIOptions);
                view.PrintDict(model.PlayerAbilityScore);
                string pChoice = view.GetLine();
                while (!pASIOptions.Contains(pChoice))
                {
                    view.PrintLine("Choice must be one of the following:");
                    view.PrintSet(pASIOptions);
                    pChoice = view.GetLine();
                }
                AbilityIncrease(pChoice);
                if (model.PlayerAbilityScore[pChoice].Equals(20))
                    pASIOptions.Remove(pChoice);
            }
        }

        private void AbilityIncrease(string pAbility)
        {
            model.PlayerAbilityScore[pAbility] += 1;
        }

        private void AddFeat()
        {
            List<Type> featOptions = new List<Type>();
            foreach (var t in IFeat.allFeats)
            {
                bool ProfPreReq = true;
                bool ASPreReq = true;
                bool ClassPreReq = true;
                IFeat temp = IFeat.FactoryMethod(t.Name);
                if(temp.FeatProficiencyPreReq.Count > 0)
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
                if(temp.FeatAbilityScorePreReq.Count > 0)
                {
                    ASPreReq = false;
                    foreach (string ability in temp.FeatAbilityScorePreReq)
                    {
                        if(model.PlayerAbilityScore[ability] >= 13)
                        {
                            ASPreReq = true;
                            break;
                        }
                    }
                }
                if(temp.FeatClassPreReq.Count > 0)
                {
                    ClassPreReq = false;
                    if (temp.FeatClassPreReq.Contains(model.PlayerClass.ClassName))
                        ClassPreReq = true;
                }

                if (ProfPreReq && ASPreReq && ClassPreReq && !model.PlayerFeats.Any(x => x.FeatName == temp.FeatName))
                    featOptions.Add(t);
            }

            if(featOptions.Count == 0)
            {
                view.PrintLine("There are no feats available for this character. Letting the player increase abilities instead.");
                ASI();
                return;
            }

            view.PrintLine("What feat would you like to take?");
            view.PrintOptions(featOptions);
            string pFeat = view.GetLine().Replace(" ", "");
            while (!featOptions.Any(x => x.Name == pFeat))
            {
                view.PrintLine("Choice must be one of the following:");
                view.PrintOptions(featOptions);
                pFeat = view.GetLine().Replace(" ", "");
            }

            IFeat selectedFeat = IFeat.FactoryMethod(pFeat);
            model.PlayerFeats.Add(selectedFeat);

            if(selectedFeat.FeatAbilityScoreEffect.Count > 0)
            {
                HashSet<string> ASChecker = new HashSet<string>(selectedFeat.FeatAbilityScoreEffect);
                HashSet<string> ASOptions = new HashSet<string>();
                foreach (string ability in ASChecker)
                {
                    if (model.PlayerAbilityScore[ability] < 20)
                        ASOptions.Add(ability);
                }
                if(ASOptions.Count > 1)
                {
                    view.PrintLine("Which ability would you like to increase?");
                    view.PrintSet(ASOptions);
                    view.PrintDict(model.PlayerAbilityScore);
                    string pAbility = view.GetLine();
                    while (!ASOptions.Contains(pAbility))
                    {
                        view.PrintLine("Choice must be one of the following:");
                        view.PrintSet(ASOptions);
                        pAbility = view.GetLine();
                    }
                    AbilityIncrease(pAbility);
                }
                else
                {
                    foreach (string prof in ASOptions)
                        AbilityIncrease(prof);
                }
            }

            if(selectedFeat.FeatProficiencyEffect.Count > 0)
            {
                model.PlayerProficiencies.UnionWith(selectedFeat.FeatProficiencyEffect);
            }

            if (selectedFeat.FeatExtraEffects)
                selectedFeat.FeatApplyExtraEffects(this.model, this.view);
        }

        // The code below here rolls a random character. There's probably a better way to do it but for now I'm gonna leave it.

        public void RandomCharacter(int level, string name)
        {
            randomCharacter = true;
            model.PlayerName = name;
            IRace pRace = RandomRace();
            model.PlayerRace = pRace;
            RandomRaceSpecifics();
            IClass pClass = RandomClass();
            model.PlayerClass = pClass;
            RandomClassSpecifics();
            RollStats();
            model.PlayerLevel = level;

            if (model.PlayerLevel > 1)
                GreaterLevel();

            view.PrintLine($"\n\n{model}");
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
