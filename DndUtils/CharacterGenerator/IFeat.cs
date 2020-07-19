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
        }
    }

    class Athlete : IFeat
    {
        public Athlete()
        {
            _featName = "Athelte";
            _featDescription =
                "You have undergone extensive physical training to gain the following benefits:\n" +
                "\t- Increase your Strength or Dexterity score by 1, to a maximum of 20.\n" +
                "\t- When you are prone, standing up uses only 5 feet of movement.\n" +
                "\t- Climbing doesn't halve your speed.\n" +
                "\t- You can make a running long ump or a running high jump after moving only 5 feet on foot, rather than 10 feet.\n";
            _featAbilityScoreEffect = new HashSet<string>
            {
                "STR",
                "DEX",
            };
        }
    }

    class Actor : IFeat
    {
        public Actor()
        {
            _featName = "Actor";
            _featDescription = 
                "Skilled at mimicry and dramatics, you gain the following benefits:\n" +
                "\t- Increase your Charisma score by 1, to a maximum of 20.\n" +
                "\t- You have advantage on Charisma (Deception) and Charisma (Performance) checks when trying to pass yourself off as a different person.\n" +
                "\t- You can mimic the speech of another person or the sounds made by other creatures. You must have heard the person speaking, or heard the creature " +
                "make the sound for at least 1 minute. A successful Wisdom (Insight) check contested by your Charisma (Deception) check allows a listener to determine that the effect is faked.\n";
            _featAbilityScoreEffect = new HashSet<string>
            {
                "CHA",
            };
        }
    }

    class Charger : IFeat
    {
        public Charger()
        {
            _featName = "Charger";
            _featDescription = 
                "When you use your action to Dash, you can use a bonus action to make one melee weapon attack or to shove a creature.\n" +
                "If you move at least 10 feet in a straight line immediately before taking this bonus action, you either gain a +5 bonus to the attack's damage roll (if you choose to make a " +
                "melee attack and hit) or push the target up to 10 feet away from you (if you choose to shove and you succeed).\n";
        }
    }

    class CrossbowExpert : IFeat
    {
        public CrossbowExpert()
        {
            _featName = "Crossbow Expert";
            _featDescription = 
                "Thanks to extensive practice with the crossbow, you gain the following benefits:\n" +
                "\t- You ignore the loading qualiy of crossbows with which you are proficient.\n" +
                "\t- Being within 5 feet of a hostile creature doesn't impose disadvantage on your ranged attack rolls.\n" +
                "\t- When you use the Attack action and attack with a one-handed weapon, you can use a bonus action to attack with a loaded hand crossbow you are holding.\n";
        }
    }

    class DefensiveDuelist : IFeat
    {
        public DefensiveDuelist()
        {
            _featName = "Defensive Duelist";
            _featDescription = 
                "Prerequisite: Dexterity 13 or higher\n" +
                "When you are wielding a finesse weapon with which you are proficient and another creature hits you with a melee attack, you can use your reaction to add your " +
                "proficiency bonus to your AC for that attack, potentially causing that attack to miss you.\n";
            _featAbilityScorePreReq = new HashSet<string>
            {
                "DEX",
            };
        }
    }

    class DualWielder : IFeat
    {
        public DualWielder()
        {
            _featName = "Dual Wielder";
            _featDescription =
                "You master fighting with two weapons, gaining the following benefits:\n" +
                "\t- You gain +1 bonus to your AC while you are wielding a separate melee weapon in each hand.\n" +
                "\t- You can use two-weapon fighting even when the one-handed melee weapons you are wielding aren't light.\t" +
                "\t- You can draw or stow two one-handed melee weapons when you would normally be able to draw or stow only one.\n";
        }
    }

    class DungeonDelver : IFeat
    {
        public DungeonDelver()
        {
            _featName = "Dungeon Delver";
            _featDescription =
                "Alert to hidden traps and secret doors found in many dungeons, you gain the following benefits:\n" +
                "\t- You have advantage on Wisdom (Perception) and Intelligence (Investigation) checks made to detect the presence of secret doors.\n" +
                "\t- You have advantage on saving throws madde to avoid or resist traps.\n" +
                "\t- You have resistance to the damage dealth by traps.\n" +
                "\t- You can search for traps while traveling at a normal pace, instead of at a slow pace.\n";
        }
    }

    class Durable : IFeat
    {
        public Durable()
        {
            _featName = "Durable";
            _featDescription = 
                "Hardy and resilient, you gain the following benefits:\n" +
                "\t- Increase your Constitution score by 1, to a maximum of 20." +
                "\t- When you roll a Hit Die to regain hit points, the minimum number of hit points you regain from the roll equals twice your Constitution modifier (minimum of 2).\n";
            _featAbilityScoreEffect = new HashSet<string>
            {
                "CON",
            };
        }
    }

    class ElementalAdept : IFeat
    {
        public ElementalAdept()
        {
            _featName = "Elemental Adept";
            _featDescription = 
                "Prerequisite: The ability to cast at least one spell.\n" +
                "When you gain the feat, choose one of the following damage types: acid, cold, fire, lightning, or thunder.\n" +
                "Spells you cast ignore resistance to damage of the chosen type. In addition, when you roll damage for a spell you cast that deals damage of that type, " +
                "you can treat any 1 on a damage die as a 2.\n" +
                "You can select this feat multiple times. Each time you do so, you must choose a different damage type.\n";
            _featClassPreReq = SpellCastingClasses;
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

    class GreatWeaponMaster : IFeat
    {
        public GreatWeaponMaster()
        {
            _featName = "Great Weapon Master";
            _featDescription = 
                "You've learned to put the weight of a weapon to your advantage, letting its momentum empower your strikes. You gain the following benefits:\n" +
                "\t- On your turn, when you score a critical hit with a melee weapon or reduce a creature to 0 hit points with one, you can make one melee weapon attack as a bonus action.\n" +
                "\t- Before you make a melee attack with a heavy weapon that you are proficient with, you can choose to take a -5 penalty to the attack roll. " +
                "If the attack hits, you add +10 to the attack's damage.\n";
        }
    }

    class Healer : IFeat
    {
        public Healer()
        {
            _featName = "Healer";
            _featDescription =
                "You are an able physician, allowing you to mend wounds quickly and get your allies back in the fight. You gain the following benefits:\n" +
                "\t- When you use a healer's kit to stabilize a dying creature, that creature also regains 1 hit point.\n" +
                "\t- As an action, you can spend one use of a healer’s kit to tend to a creature and restore 1d6 + 4 hit points to it, plus additional hit points " +
                "equal to the creature’s maximum number of Hit Dice. The creature can’t regain hit points from this feat again until it finishes a short or long rest.\n";
        }
    }

    class HeavilyArmored : IFeat
    {
        public HeavilyArmored()
        {
            _featName = "Heavily Armored";
            _featDescription =
                "Prerequisite: Proficiency with medium armor\n" +
                "You have trained to master the use of heavy armor, gaining the following benefits:\n" +
                "\t- Increase your Strength score by 1, to a maximum of 20.\n" +
                "\t- You gain proficiency with heavy armor.\n";
            _featProficiencyPreReq = new HashSet<string>()
            {
                "Medium armor",
            };

            _featAbilityScoreEffect = new HashSet<string>()
            {
                "STR",
            };

            _featProficiencyEffect = new HashSet<string>()
            {
                "Heavy armor",
            };
        }
    }

    class HeavyArmorMaster : IFeat
    {
        public HeavyArmorMaster()
        {
            _featName = "Heavy Armor Master";
            _featDescription =
                "Prerequisite: Proficiency with heavy armor\n" +
                "You can use your armor to deflect strikes that would kill others. You gain the following benefits:\n" +
                "\t- Increase your Strength score by 1, to a maximum of 20.\n" +
                "\t- While you are wearing heavy armor, bludgeoning, piercing, and slashing damage that you take from non-magical weapons is reduced by 3.\n";
            _featProficiencyPreReq = new HashSet<string>()
            {
                "Heavy armor",
            };
            _featAbilityScoreEffect = new HashSet<string>()
            {
                "STR"
            };
        }
    }

    class InspiringLeader : IFeat
    {
        public InspiringLeader()
        {
            _featName = "Inspiring Leader";
            _featDescription = 
                "Prerequisite: Charisma 13 or higher\n" +
                "You can spend 10 minutes inspiring your companions, shoring up their resolve to fight. When you do so, choose up to six friendly creatures (which can include yourself) " +
                "within 30 feet of you who can see or hear you and who can understand you. Each creature can gain temporary hit points equal to your level + your Charisma modifier. " +
                "A creature can’t gain temporary hit points from this feat again until it has finished a short or long rest.\n";
            _featAbilityScorePreReq = new HashSet<string>()
            {
                "CHA",
            };
        }
    }

    class KeenMind : IFeat
    {
        public KeenMind()
        {
            _featName = "Keen Mind";
            _featDescription =
                "You have a mind that can track time, direction, and detail with uncanny precision. You gain the following benefits.\n" +
                "\t- Increase your Intelligence score by 1, to a maximum of 20.\n" +
                "\t- You always know which way is north.\n" +
                "\t- You always know the number of hours left before the next sunrise or sunset.\n" +
                "\t- You can accurately recall anything you have seen or heard within the past month.\n";
            _featAbilityScoreEffect = new HashSet<string>()
            {
                "INT",
            };
        }
    }

    class LightlyArmored : IFeat
    {
        public LightlyArmored()
        {
            _featName = "Lightly Armored";
            _featDescription =
                "You have trained to master the use of light armor, gaining the following benefits:\n" +
                "\t- Increase your Strength or Dexterity score by 1, to a maximum of 20.\n" +
                "\t- You gain proficiency with light armor.";
            _featAbilityScoreEffect = new HashSet<string>()
            {
                "STR",
                "DEX",
            };
            _featProficiencyEffect = new HashSet<string>()
            {
                "Light armor",
            };
        }
    }

    class Linguist : IFeat
    {
        public Linguist()
        {
            _featName = "Linguist";
            _featDescription =
                "You have studied languages and codes, gaining the following benefits:\n" +
                "\t- Increase your Intelligence score by 1, to a maximum of 20.\n" +
                "\t- You learn three languages of your choice.\n" +
                "\t- You can ably create written ciphers. Others can’t decipher a code you create unless you teach them, they succeed on an Intelligence check (DC equal to your " +
                "Intelligence score + your proficiency bonus), or they use magic to decipher it.";
            _featAbilityScoreEffect = new HashSet<string>()
            {
                "INT",
            };
        }
    }

    class Lucky : IFeat
    {
        public Lucky()
        {
            _featName = "Lucky";
            _featDescription =
                "You have inexplicable luck that seems to kick in at just the right moment.\n" +
                "You have 3 luck points. Whenever you make an attack roll, an ability check, or a saving throw, you can spend one luck point to roll an additional d20. You can choose " +
                "to spend one of your luck points after you roll the die, but before the outcome is determined. You choose which of the d20s is used for the attack roll, ability check, or " +
                "saving throw.\n" +
                "You can also spend one luck point when an attack roll is made against you. Roll a d20, and then choose whether the attack uses the attacker’s roll or yours. " +
                "If more than one creature spends a luck point to influence the outcome of a roll, the points cancel each other out; no additional dice are rolled.\n" +
                "You regain your expended luck points when you finish a long rest.\n";
        }
    }

    class MageSlayer : IFeat
    {
        public MageSlayer()
        {
            _featName = "Mage Slayer";
            _featDescription =
                "You have practiced techniques useful in melee combat against spellcasters, gaining the following benefits:\n" +
                "\t- When a creature within 5 feet of you casts a spell, you can use your reaction to make a melee weapon attack against that creature.\n" +
                "\t- When you damage a creature that is concentrating on a spell, that creature has disadvantage on the saving throw it makes to maintain its concentration.\n" +
                "\t- You have advantage on saving throws against spells cast by creatures within 5 feet of you.\n";
        }
    }

    class MagicInitiate : IFeat
    {
        public MagicInitiate()
        {
            _featName = "Magic Initiate";
            _featDescription =
                "Choose a class: bard, cleric, druid, sorcerer, warlock, or wizard. You learn two cantrips of your choice from that class’s spell list.\n" +
                "In addition, choose one 1st-level spell from that same list. You learn that spell and can cast it at its lowest level. Once you cast it, " +
                "you must finish a long rest before you can cast it again.\n" +
                "Your spellcasting ability for these spells depends on the class you chose: Charisma for bard, sorcerer, or warlock; Wisdom for cleric " +
                "or druid: or Intelligence for wizard.\n";
        }
    }

    class MartialAdept : IFeat
    {
        public MartialAdept()
        {
            _featName = "Martial Adept";
            _featDescription =
                "You have martial training that allows you to perform special combat maneuvers. You gain the following benefits:\n" +
                "\t- You learn two maneuvers of your choice from among those available to the Battle Master archetype in the " +
                "fighter class. If a maneuver you use requires your target to make a saving throw to resist the maneuver’s " +
                "effects, the saving throw DC equals 8 + your proficiency bonus + your Strength or Dexterity modifier (your choice).\n" +
                "\t- If you already have superiority dice, you gain one more; otherwise, you have one superiority die, which " +
                "is a d6. This die is used to fuel your maneuvers. A superiority die is expended when you use it. You " +
                "regain your expended superiority d ice when you finish a short or long rest.\n";
        }
    }

    class MediumArmorMaster : IFeat
    {
        public MediumArmorMaster()
        {
            _featName = "Medium Armor Master";
            _featDescription =
                "Prerequisite: Proficiency with medium armor\n" +
                "You have practiced moving in medium armor to gain the following benefits:\n" +
                "\t- Wearing medium armor doesn't impose disadvantage on your Dexterity (Stealth) checks.\n" +
                "\t- When you wear medium armor, you can add 3, rather than 2, to your AC if you have a Dexterity of 16 or higher.\n";
            _featProficiencyPreReq = new HashSet<string>()
            {
                "Medium armor",
            };
        }
    }

    class Mobile : IFeat
    {
        public Mobile()
        {
            _featName = "Mobile";
            _featDescription =
                "You are exceptionally speedy and agile. You gain the following benefits:\n" +
                "\t- Your speed increases by 10 feet.\n" +
                "\t- When you use the Dash action, difficult terrain doesn't cost you extra movement on that turn.\n" +
                "\t- When you make a melee attack against a creature, you don't provoke opportunity attacks from that creature for the rest of the turn, whether you hit or not.\n";
        }
    }

    class ModeratelyArmored : IFeat
    {
        public ModeratelyArmored()
        {
            _featName = "Moderately Armored";
            _featDescription =
                "Prerequisite: Proficiency with light armor\n" +
                "You have trained to master the use of medium armor and shields, gaining the following benefits:\n" +
                "\t- Increase your Strength or Dexterity score by 1, to a maximum of 20.\n" +
                "\t- You gain proficiency with medium armor and shields.\n";
            _featProficiencyPreReq = new HashSet<string>()
            {
                "Light armor",
            };

            _featAbilityScoreEffect = new HashSet<string>()
            {
                "STR",
                "DEX",
            };

            _featProficiencyEffect = new HashSet<string>()
            {
                "Medium armor",
                "Shields",
            };
        }
    }

    class MountedCombat : IFeat
    {
        public MountedCombat()
        {
            _featName = "Mounted Combat";
            _featDescription =
                "You are a dangerous foe to face while mounted. While you are mounted and aren't incapacitated, you gain the following benefits:\n" +
                "\t- You have advantage on melee attack rolls against any unmounted creature that is smaller than your mount.\n" +
                "\t- You can force an attack targeted at your mount to target you instead.\n" +
                "\t- If your mount is subjected to an effect that allows it to make a Dexterity saving throw to take only half damage, " +
                "it instead takes no damage if it succeeds on the saving throw, and only half damage if it fails.\n";
        }
    }

    class Observant : IFeat
    {
        public Observant()
        {
            _featName = "Observant";
            _featDescription =
                "Quick to notice details of your environment, you gain the following benefits:\n" +
                "\t- Increase your Intelligence or Wisdom score by 1, to a maximum of 20.\n" +
                "\t- If you can see a creature’s mouth while it is speaking a language you understand, you can interpret what it’s saying by reading its lips.\n" +
                "\t- You have a +5 bonus to your passive Wisdom (Perception) and passive Intelligence (Investigation) scores.\n";
        }
    }

    class PolearmMaster : IFeat
    {
        public PolearmMaster()
        {
            _featName = "Polearm Master";
            _featDescription =
                "You can keep your enemies at bay with reach weapons. You gain the following benefits:\n" +
                "\t- When you take the Attack action and attack with only a glaive, halberd, or quarterstaff, you can use a bonus " +
                "action to make a melee attack with the opposite end of the weapon. The weapon’s damage die for this attack " +
                "is a d4, and the attack deals bludgeoning damage.\n" +
                "\t- While you are wielding a glaive, halberd, pike, or quarterstaff,other creatures provoke an opportunity attack " +
                "from you when they enter your reach.\n";
        }
    }

    class Resilient : IFeat
    {
        public Resilient()
        {
            _featName = "Resilient";
            _featDescription =
                "Choose one ability score. You gain the following benefits:\n" +
                "\t- Increase the chosen ability score by 1, to a maximum of 20.\n" +
                "\t- You gain proficiency in saving throws using the chosen ability.";
            _featAbilityScoreEffect = new HashSet<string>()
            {
                "STR",
                "DEX",
                "CON",
                "INT",
                "WIS",
                "CHA",
            };
        }
    }

    class RitualCaster : IFeat
    {
        public RitualCaster()
        {
            _featName = "Ritual Caster";
            _featDescription =
                "Prerequisite: Intelligence or Wisdom 13 or higher\n" +
                "You have learned a number of spells that you can cast as rituals. These spells are written in a ritual book, which you must have in hand while casting one of them.\n" +
                "When you choose this feat, you acquire a ritual book holding two 1st-level spells of your choice. Choose one of the following classes: bard, cleric, druid, sorcerer, " +
                "warlock, or wizard. You must choose your spells from that class’s spell list, and the spells you choose must have the ritual tag. The class you choose also " +
                "determines your spellcasting ability for these spells: Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; or Intelligence for wizard.\n" +
                "If you come across a spell in written form, such as a magical spell scroll or a wizard's spellbook, you might be able to add it to your ritual book. The spell must be " +
                "on the spell list for the class you chose, the spell's level can be no higher than half your level (rounded up), and it must have the ritual tag. The process of copying the " +
                "spell into your ritual book takes 2 hours per level of the spell, and costs 50 gp per level. The cost represents material components you expend as you experiment " +
                "with the spell to master it, as well as the fine inks you need to record it.\n";
            _featAbilityScorePreReq = new HashSet<string>()
            {
                "INT",
                "WIS",
            };
        }
    }

    class SavageAttacker : IFeat
    {
        public SavageAttacker()
        {
            _featName = "Savage Attacker";
            _featDescription =
                "Once per turn when you roll damage for a melee weapon attack, you can reroll the weapon's damage dice and use either total.\n";
        }
    }

    class Sentinel : IFeat
    {
        public Sentinel()
        {
            _featName = "Sentinel";
            _featDescription =
                "You have mastered techniques to take advantage of every drop in any enemy's guard, gaining the following benefits:\n" +
                "\t- When you hit a creature with an opportunity attack, the creature’s speed becomes 0 for the rest of the turn.\n" +
                "\t- Creatures within 5 feet of you provoke opportunity attacks from you even if they take the Disengage action before leaving your reach.\n" +
                "\t- When a creature within 5 feet of you makes an attack against a target other than you (and that target doesn't " +
                "have this feat), you can use your reaction to make a melee weapon attack against the attacking creature.\n";
        }
    }

    class Sharpshooter : IFeat
    {
        public Sharpshooter()
        {
            _featName = "Sharpshooter";
            _featDescription =
                "You have mastered ranged weapons and can make shots that others find impossible. You gain the following benefits:\n" +
                "\t- Attacking at long range doesn't impose disadvantage on your ranged weapon attack rolls.\n" +
                "\t- Your ranged weapon attacks ignore half cover and three-quarters cover.\n" +
                "\t- Before you make an attack with a ranged weapon that you are proficient with, you can choose to take a -5 " +
                "penalty to the attack roll. If the attack hits, you add +10 to the attack’s damage.\n";
        }
    }

    class ShieldMaster : IFeat
    {
        public ShieldMaster()
        {
            _featName = "Shield Master";
            _featDescription =
                "You use shields not just for protection but also for offense. You gain the following benefits while you are wielding a shield:\n" +
                "\t- If you take the Attack action on your turn, you can use a bonus action to try to shove a creature within 5 feet of you with your shield.\n" +
                "\t- If you aren't incapacitated, you can add your shield’s AC bonus to any Dexterity saving throw you make against " +
                "a spell or other harmful effect that targets only you.\n" +
                "\t- If you are subjected to an effect that allows you to make a Dexterity saving throw to take only half damage, you can use your reaction " +
                "to take no damage if you succeed on the saving throw, interposing your shield between yourself and the source of the effect.\n";
        }
    }

    class Skilled : IFeat
    {
        public Skilled()
        {
            _featName = "Skilled";
            _featDescription =
                "You gain proficiency in any combination of three skills or tools of your choice.\n";
        }
    }

    class Skulker : IFeat
    {
        public Skulker()
        {
            _featName = "Skulker";
            _featDescription =
                "Prerequisite: Dexterity 13 or higher\n" +
                "You are expert at slinking through shadows. You gain the following benefits:\n" +
                "\t- You can try to hide when you are lightly obscured from the creature from which you are hiding.\n" +
                "\t- When you are hidden from a creature and miss it with a ranged weapon attack, making the attack doesn't reveal your position.\n" +
                "\t- Dim light doesn't impose disadvantage on your Wisdom (Perception) checks relying on sight.";
            _featAbilityScorePreReq = new HashSet<string>()
            {
                "DEX",
            };
        }
    }

    class SpellSniper : IFeat
    {
        public SpellSniper()
        {
            _featName = "Spell Sniper";
            _featDescription =
                "Prerequisite: The ability to cast at least one spell\n" +
                "You have learned techniques to enhance your attacks with certain kinds of spells, gaining the following benefits:\n" +
                "\t- When you cast a spell that requires you to make an attack roll, the spell’s range is doubled.\n" +
                "\t- Your ranged spell attacks ignore half cover and three-quarters cover.\n" +
                "\t- You learn one cantrip that requires an attack roll. Choose the cantrip from the bard, cleric, druid, sorcerer, " +
                "warlock, or wizard spell list. Your spellcasting ability for this cantrip depends on the spell list you " +
                "chose from: Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; or Intelligence for wizard.\n";
            _featClassPreReq = SpellCastingClasses;
        }
    }

    class TavernBrawler : IFeat
    {
        public TavernBrawler()
        {
            _featName = "Tavern Brawler";
            _featDescription =
                "Accustomed to rough-and-tumble fighting using whatever weapons happen to be at hand, you gain the following benefits:\n" +
                "\t- Increase your Strength or Constitution score by 1, to a maximum of 20.\n" +
                "\t- You are proficient with improvised weapons and unarmed strikes.\n" +
                "\t- Your unarmed strike uses a d4 for damage.\n" +
                "\t- When you hit a creature with an unarmed strike or an improvised weapon on your turn, you can use a bonus action to attempt to grapple the target.\n";
            _featAbilityScoreEffect = new HashSet<string>()
            {
                "STR",
                "CON",
            };
            _featProficiencyEffect = new HashSet<string>()
            {
                "Improvised weapons",
                "Unarmed strikes",
            };
        }
    }

    class Tough : IFeat
    {
        public Tough()
        {
            _featName = "Tough";
            _featDescription =
                "Your hit point maximum increases by an amount equal to twice your level when you gain this feat. Whenever " +
                "you gain a level thereafter, your hit point maximum increases by an additional 2 hit points.\n";
        }
    }

    class WarCaster : IFeat
    {
        public WarCaster()
        {
            _featName = "War Caster";
            _featDescription =
                "Prerequisite: The ability to cast at least one spell\n" +
                "You have practiced casting spells in the midst of combat, learning techniques that grant you the following benefits:\n" +
                "\t- You have advantage on Constitution saving throws that you make to maintain your concentration on a spell when you take damage.\n" +
                "\t- You can perform the somatic components of spells even when you have weapons or a shield in one or both hands.\n" +
                "\t- When a hostile creature's movement provokes an opportunity attack from you, you can use your reaction " +
                "to cast a spell at the creature, rather than making an opportunity attack. The spell must have a casting " +
                "time of 1 action and must target only that creature.\n";
            _featClassPreReq = SpellCastingClasses;
        }
    }

    class WeaponMaster : IFeat
    {
        public WeaponMaster()
        {
            _featName = "Weapon Master";
            _featDescription =
                "You have practiced extensively with a variety of weapons, gaining the following benefits:\n" +
                "\t- Increase your Strength or Dexterity score by 1, to a maximum of 20.\n" +
                "\t- You gain proficiency with four weapons of your choice.\n";
            _featAbilityScoreEffect = new HashSet<string>()
            {
                "STR",
                "DEX",
            };
        }
    }
}
