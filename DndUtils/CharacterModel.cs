using DndUtils.Class;
using DndUtils.Race;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils
{
    class CharacterModel
    {
        public string PlayerName { get; set; }

        public IRace PlayerRace { get; set; }

        public IClass PlayerClass { get; set; }

        private int _playerLevel;
        public int PlayerLevel
        {
            get => _playerLevel;
            set
            {
                if ((value > 0) && (value < 21))
                    _playerLevel = value;
            }
        }

        private int _playerHealth;
        public int PlayerHealth
        {
            get => _playerHealth;
            set
            {
                if (value > 0)
                    _playerHealth = value;
            }
        }

        public HashSet<string> PlayerProficiencies { get; set; }

        private Dictionary<string, int> _playerAbilityScore;
        public Dictionary<string, int> PlayerAbilityScore
        {
            get => _playerAbilityScore;
            set
            {
                if (value.Count == 6)
                    _playerAbilityScore = value;
            }
        }

        public CharacterModel() { }

        public CharacterModel(string pName, IRace pRace, IClass pClass, int pLevel, int pHealth, HashSet<string> pProficiencies, Dictionary<string, int> pAbility)
        {
            PlayerName = pName;
            PlayerRace = pRace;
            PlayerClass = pClass;
            PlayerLevel = pLevel;
            PlayerHealth = pHealth;
            PlayerProficiencies = pProficiencies;
            PlayerAbilityScore = pAbility;
        }
    }
}
