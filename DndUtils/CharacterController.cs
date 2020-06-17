using DndUtils.Class;
using DndUtils.Race;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils
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
            IRace pRace = ChooseRace();
            model.PlayerRace = pRace;
            RaceSpecifics();
            IClass pClass = ChooseClass();
            model.PlayerClass = pClass;
            ClassSpecifics();
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
    }
}
