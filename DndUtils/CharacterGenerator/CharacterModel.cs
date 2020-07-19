using DndUtils.CharacterGenerator.Class;
using DndUtils.CharacterGenerator.Race;
using DndUtils.CharacterGenerator.Feat;
using System;
using System.Collections.Generic;
using System.Text;

namespace DndUtils.CharacterGenerator
{
    class CharacterModel
    {
        public string PlayerName { get; set; }

        private IRace _playerRace;
        public IRace PlayerRace
        {
            get => _playerRace;
            set
            {
                _playerRace = value;
                PlayerProficiencies.UnionWith(value.RaceProficiencies);
                PlayerLanguages.UnionWith(value.RaceLanguages);
            }
        }

        private IClass _playerClass;
        public IClass PlayerClass
        {
            get => _playerClass;
            set
            {
                _playerClass = value;
                PlayerProficiencies.UnionWith(value.ClassProficiencies);
            }
        }

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

        private int _playerRolledHealth;
        public int PlayerRolledHealth
        {
            get => _playerRolledHealth;
            set
            {
                if (value > 0)
                    _playerRolledHealth = value;
            }
        }
        private int _playerHealthBonus = 0;
        public int PlayerHealthBonus
        {
            get => _playerHealthBonus;
            set
            {
                if (value > 0)
                    _playerHealthBonus = 0;
            }
        }
        public int PlayerTotalHealth => _playerRolledHealth + (PlayerAbilityModifier["CON"] * _playerLevel);

        private int _playerSpeedBonus;
        public int PlayerSpeedBonus
        {
            get => _playerSpeedBonus;
            set
            {
                if (value > 0)
                    _playerSpeedBonus = value;
            }
        }
        public int PlayerSpeed => PlayerRace.RaceSpeed + PlayerSpeedBonus;


        public HashSet<string> PlayerLanguages { get; set; }
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

        public Dictionary<string, int> PlayerAbilityModifier
        {
            get
            {
                Dictionary<string, int> t = new Dictionary<string, int>();
                foreach (KeyValuePair<string, int> kv in PlayerAbilityScore)
                {
                    t.Add(kv.Key, (kv.Value - 10) / 2);
                }
                return t;
            }
        }

        public HashSet<IFeat> PlayerFeats { get; set; }

        public CharacterModel() 
        {
            PlayerProficiencies = new HashSet<string>();
            PlayerLanguages = new HashSet<string>();
            PlayerFeats = new HashSet<IFeat>();
        }

        public CharacterModel(string pName, IRace pRace, IClass pClass, int pLevel, int pRolledHealth, HashSet<string> pProficiencies, Dictionary<string, int> pAbility)
        {
            PlayerName = pName;
            PlayerRace = pRace;
            PlayerClass = pClass;
            PlayerLevel = pLevel;
            PlayerRolledHealth = pRolledHealth;
            PlayerProficiencies = pProficiencies;
            PlayerAbilityScore = pAbility;
        }

        public override string ToString()
        {
            string output = $"{PlayerName}\n" +
                $"{PlayerRace.RaceName} -- {PlayerClass.ClassName}\n" +
                $"Level {PlayerLevel}\n" +
                $"Health {PlayerTotalHealth}\n" +
                $"Speed {PlayerSpeed}\n" +
                $"Languages:\n";
            foreach (string lang in PlayerLanguages)
                output += $"\t{lang}\n";
            output += $"Proficiencies: \n";
            foreach (string prof in PlayerProficiencies)
                output += $"\t{prof}\n";
            output += "Ability scores:\n";
            foreach (KeyValuePair<string, int> kv in PlayerAbilityScore)
                output += $"\t{kv.Key} -- {kv.Value} ({PlayerAbilityModifier[kv.Key]})\n";
            output += "Feats:\n";
            foreach (IFeat feat in PlayerFeats)
                output += $"\t{feat.FeatName}\n";
            return output;
        }
    }
}
