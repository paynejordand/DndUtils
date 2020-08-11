using DndUtils.CharacterGenerator;
using DndUtils.CharacterGenerator.Feat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DndUtils
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PlayerSheetWindow : Window
    {
        CharacterController cc;
        public PlayerSheetWindow(object obj)
        {
            InitializeComponent();
            cc = obj as CharacterController;

            PlayerName.Text = cc.GetPlayerName();
            ClassLevel.Text = $"{cc.GetClass().ClassName}  {cc.GetPlayerLevel()}";
            Race.Text = $"{cc.GetRace().RaceName}";
            StrScore.Text = cc.GetStat("STR").ToString();
            StrMod.Text = cc.GetStatMod("STR").ToString();
            DexScore.Text = cc.GetStat("DEX").ToString();
            DexMod.Text = cc.GetStatMod("DEX").ToString();
            ConScore.Text = cc.GetStat("CON").ToString();
            ConMod.Text = cc.GetStatMod("CON").ToString();
            IntScore.Text = cc.GetStat("INT").ToString();
            IntMod.Text = cc.GetStatMod("INT").ToString();
            WisScore.Text = cc.GetStat("WIS").ToString();
            WisMod.Text = cc.GetStatMod("WIS").ToString();
            ChaScore.Text = cc.GetStat("CHA").ToString();
            ChaMod.Text = cc.GetStatMod("CHA").ToString();
            Speed.Text = cc.GetSpeed().ToString();
            Init.Text = cc.GetStatMod("DEX").ToString();
            CurrentHP.Text = cc.GetHealth().ToString();
            MaxHP.Text = cc.GetHealth().ToString();

            string featText = "";
            foreach(IFeat feat in cc.GetFeats())
            {
                featText += $"{feat.FeatName}\n";
            }
            Feats.Text = featText;

            HashSet<string> profs = new HashSet<string>(cc.GetProficiencies());
            if (profs.Remove("STR"))
                StrSave.Visibility = Visibility.Visible;
            if(profs.Remove("Athletics"))
                Athletics.Visibility = Visibility.Visible;
            if(profs.Remove("DEX"))
                DexSave.Visibility = Visibility.Visible;
            if(profs.Remove("Acrobatics"))
                Acrobatics.Visibility = Visibility.Visible;
            if(profs.Remove("Sleight of Hand"))
                SleightOfHand.Visibility = Visibility.Visible;
            if(profs.Remove("Stealth"))
                Stealth.Visibility = Visibility.Visible;
            if(profs.Remove("CON"))
                ConSave.Visibility = Visibility.Visible;
            if(profs.Remove("INT"))
                IntSave.Visibility = Visibility.Visible;
            if(profs.Remove("Arcana"))
                Arcana.Visibility = Visibility.Visible;
            if(profs.Remove("History"))
                Hisory.Visibility = Visibility.Visible;
            if(profs.Remove("Investigation"))
                Investigation.Visibility = Visibility.Visible;
            if(profs.Remove("Nature"))
                Nature.Visibility = Visibility.Visible;
            if(profs.Remove("Religion"))
                Religion.Visibility = Visibility.Visible;
            if(profs.Remove("WIS"))
                WisSave.Visibility = Visibility.Visible;
            if(profs.Remove("Animal Handling"))
                AnimalHandling.Visibility = Visibility.Visible;
            if(profs.Remove("Insight"))
                Insight.Visibility = Visibility.Visible;
            if(profs.Remove("Medicine"))
                Medicine.Visibility = Visibility.Visible;
            if(profs.Remove("Perception"))
                Perception.Visibility = Visibility.Visible;
            if(profs.Remove("Survival"))
                Survival.Visibility = Visibility.Visible;
            if(profs.Remove("CHA"))
                ChaSave.Visibility = Visibility.Visible;
            if(profs.Remove("Deception"))
                Deception.Visibility = Visibility.Visible;
            if(profs.Remove("Intimidation"))
                Intimidation.Visibility = Visibility.Visible;
            if(profs.Remove("Performance"))
                Performance.Visibility = Visibility.Visible;
            if(profs.Remove("Persuasion"))
                Persuasion.Visibility = Visibility.Visible;

            string profText = "";
            foreach(string prof in profs.Union(cc.GetLanguages()))
            {
                profText += $"{prof}, ";
            }
            OtherProfs.Text = profText;
        }

        private void SaveCharacter(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog
            {
                PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF")
            };
            printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
            printDialog.PrintTicket.PageScalingFactor = 100;
            printDialog.PrintVisual(PlayerSheet, cc.GetPlayerName());
        }

        private void PrintCharacter(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(PlayerSheet, cc.GetPlayerName());
            }
        }
    }
}
