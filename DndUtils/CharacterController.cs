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

        public CharacterController()
        {
            this.model = new CharacterModel();
            this.view = new CharacterView();
        }

        public void RollCharacter()
        {
            IRace pRace = ChooseRace();
            IClass pClass = ChooseClass();

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
                view.PrintLine("Selected class must be one of the following:");
                view.PrintSet(IClass.allClasses);
                pClass = view.GetLine();
            }
            return IClass.FactoryMethod(pClass);
        }
    }
}
