using DndUtils.CharacterGenerator.Race;
using DndUtils.CharacterGenerator.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator
{
    class CharacterController
    {
        private CharacterModel model;
        private CharacterView view;

        private HashSet<string> allLanguages = new HashSet<string> { "Common", "Dwarvish", "Elvish", "Giant", "Gnomish",
                           "Goblin", "Halfling", "Orc", "Abyssal", "Celestial",
                           "Draconic", "Deep Speech", "Infernal", "Primordial",
                           "Sylvan", "Undercommon"};

        private HashSet<string> artisanTools = new HashSet<string> { "Smith's Tools", "Brewer's Supplies",
                           "Mason's Tools"};

        private HashSet<string> allSkills = new HashSet<string> { "Acrobatics", "Animal Handling", "Arcana",
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
            view.PrintSet(IRace.allRaces);
            string pRace = view.GetLine();
            while (!IRace.allRaces.Contains(pRace))
            {
                view.PrintLine("Selected race must be one of the following:");
                view.PrintSet(IRace.allRaces);
                pRace = view.GetLine();
            }
            return IRace.FactoryMethod(pRace);
        }

        private IClass ChooseClass()
        {
            view.PrintLine("What class would you like to play?");
            view.PrintSet(IClass.allClasses);
            string pClass = view.GetLine();
            while (!IClass.allClasses.Contains(pClass))
            {
                view.PrintLine("Choice must be one of the following:");
                view.PrintSet(IClass.allClasses);
                pClass = view.GetLine();
            }
            return IClass.FactoryMethod(pClass);
        }

        private void RaceSpecifics()
        {
            if (model.PlayerRace is Dwarf)
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
            model.PlayerRolledHealth = model.PlayerClass.ClassHitDie;
        }

        private void GreaterLevel()
        {
            for (int i = 2; i <= model.PlayerLevel; i++)
            {
                view.PrintLine($"Curr health {model.PlayerRolledHealth}");

                model.PlayerRolledHealth += RollHitDie();
                if (model.PlayerClass.ClassASILevels.Contains(i))
                    SpecialLevel();
            }
        }

        private int RollHitDie()
        {
            int health = DiceRoller.RollDie(model.PlayerClass.ClassHitDie);
            while (health == 1)
                health = DiceRoller.RollDie(model.PlayerClass.ClassHitDie);
            view.PrintLine($"Rolled health {health}");

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
            view.PrintLine("Feats not available yet");
        }
    }
}
