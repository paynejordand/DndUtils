using DndUtils;
using DndUtils.CharacterGenerator;
using DndUtils.CharacterGenerator.Class;
using DndUtils.CharacterGenerator.Race;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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

namespace DndUtilsGUI
{
    /// <summary>
    /// Interaction logic for CharacterGeneratorRaceClassSelection.xaml
    /// </summary>
    public partial class CharacterGeneratorCustomCharacterPage : Page
    {
        CharacterController cc;
        private IRace selectedRace;// = new IRace();
        private IClass selectedClass;// = new IClass();
        private HashSet<string> selectedClassProfs = new HashSet<string>();
        private HashSet<string> selectedRaceProfs = new HashSet<string>();

        public CharacterGeneratorCustomCharacterPage(object cc)
        {
            InitializeComponent();
            this.cc = (CharacterController)cc;
            List<string> temp = new List<string>();
            foreach(var t in IRace.allRaces)
            {
                temp.Add(t.Name);
            }
            lCharacterRace.ItemsSource = temp;
            temp = new List<string>();
            foreach (var t in IClass.allClasses )
            {
                temp.Add(t.Name);
            }
            lCharacterClass.ItemsSource = temp;
            ClassSkill1.ItemsSource = new List<string>();
            ClassSkill2.ItemsSource = new List<string>();
            ArtisanTools.ItemsSource = CharacterController.artisanTools;
        }

        private void ClassChange(object sender, SelectionChangedEventArgs e)
        {
            if (!lCharacterClass.SelectedValue.Equals(null))
            {
                selectedClass = IClass.FactoryMethod(lCharacterClass.SelectedValue.ToString());
                UpdateEnabledClassSkillsComboBoxes();
                UpdateClassSkillsComboBoxesItems();
            }
        }

        private void RaceChange(object sender, SelectionChangedEventArgs e)
        {
            if (lCharacterRace.SelectedValue.Equals(null))
            {
                UpdateEnabledClassSkillsComboBoxes();
            }
            else if (!lCharacterRace.SelectedValue.Equals(null))
            {
                selectedRace = IRace.FactoryMethod(lCharacterRace.SelectedValue.ToString());
                UpdateEnabledClassSkillsComboBoxes();
                if (selectedRace is BaseDwarf)
                {
                    ArtisanToolsLabel.Visibility = Visibility.Visible;
                    ArtisanTools.IsEnabled = true;
                    ArtisanTools.Visibility = Visibility.Visible;

                    ExtraLanguageLabel.Visibility = Visibility.Hidden;
                    ExtraLanguage.IsEnabled = false;
                    ExtraLanguage.Visibility = Visibility.Hidden;
                    ExtraLanguage.SelectedIndex = -1;

                    RaceProfLabel.Visibility = Visibility.Hidden;
                    RaceProf1.IsEnabled = false;
                    RaceProf2.IsEnabled = false;
                    RaceProf1.Visibility = Visibility.Hidden;
                    RaceProf2.Visibility = Visibility.Hidden;
                    RaceProf1.SelectedIndex = -1;
                    RaceProf2.SelectedIndex = -1;
                    selectedRaceProfs.Clear();
                }
                else if (selectedRace is HighElf || selectedRace is BaseHuman)
                {
                    ArtisanToolsLabel.Visibility = Visibility.Hidden;
                    ArtisanTools.IsEnabled = false;
                    ArtisanTools.Visibility = Visibility.Hidden;
                    ArtisanTools.SelectedIndex = -1;

                    ExtraLanguageLabel.Visibility = Visibility.Visible;
                    ExtraLanguage.IsEnabled = true;
                    ExtraLanguage.Visibility = Visibility.Visible;
                    ExtraLanguage.ItemsSource = CharacterController.allLanguages.Except(selectedRace.RaceLanguages);

                    RaceProfLabel.Visibility = Visibility.Hidden;
                    RaceProf1.IsEnabled = false;
                    RaceProf2.IsEnabled = false;
                    RaceProf1.Visibility = Visibility.Hidden;
                    RaceProf2.Visibility = Visibility.Hidden;
                    RaceProf1.SelectedIndex = -1;
                    RaceProf2.SelectedIndex = -1;
                    selectedRaceProfs.Clear();
                }
                else if (selectedRace is HalfElf)
                {
                    ArtisanToolsLabel.Visibility = Visibility.Hidden;
                    ArtisanTools.IsEnabled = false;
                    ArtisanTools.Visibility = Visibility.Hidden;
                    ArtisanTools.SelectedIndex = -1;

                    ExtraLanguageLabel.Visibility = Visibility.Hidden;
                    ExtraLanguage.IsEnabled = false;
                    ExtraLanguage.Visibility = Visibility.Hidden;
                    ExtraLanguage.SelectedIndex = -1;

                    RaceProfLabel.Visibility = Visibility.Visible;
                    RaceProf1.IsEnabled = true;
                    RaceProf2.IsEnabled = true;
                    RaceProf1.ItemsSource = CharacterController.allSkills.Except(selectedRace.RaceProficiencies);
                    RaceProf2.ItemsSource = RaceProf1.ItemsSource;
                    RaceProf1.Visibility = Visibility.Visible;
                    RaceProf2.Visibility = Visibility.Visible;
                }
                else
                {
                    ArtisanToolsLabel.Visibility = Visibility.Hidden;
                    ArtisanTools.IsEnabled = false;
                    ArtisanTools.Visibility = Visibility.Hidden;
                    ArtisanTools.SelectedIndex = -1;

                    ExtraLanguageLabel.Visibility = Visibility.Hidden;
                    ExtraLanguage.IsEnabled = false;
                    ExtraLanguage.Visibility = Visibility.Hidden;
                    ExtraLanguage.SelectedIndex = -1;

                    RaceProfLabel.Visibility = Visibility.Hidden;
                    RaceProf1.IsEnabled = false;
                    RaceProf2.IsEnabled = false;
                    RaceProf1.Visibility = Visibility.Hidden;
                    RaceProf2.Visibility = Visibility.Hidden;
                    RaceProf1.SelectedIndex = -1;
                    RaceProf2.SelectedIndex = -1;
                    selectedRaceProfs.Clear();
                }
            }
        }

        private void ProfChange(object sender, SelectionChangedEventArgs e)
        {
            selectedRaceProfs.Clear();
            HashSet<string> tProf = CharacterController.allSkills;
            tProf.Except(selectedRace.RaceProficiencies);
            HashSet<string> tProf1 = new HashSet<string>(tProf);
            HashSet<string> tProf2 = new HashSet<string>(tProf);
            if (!(RaceProf1.SelectedItem is null))
            {
                selectedRaceProfs.Add(RaceProf1.SelectedItem.ToString());
                tProf2.Remove(RaceProf1.SelectedItem.ToString());
            }
            if (!(RaceProf2.SelectedItem is null))
            {
                selectedRaceProfs.Add(RaceProf2.SelectedItem.ToString());
                tProf1.Remove(RaceProf2.SelectedItem.ToString());
            }
            RaceProf1.ItemsSource = tProf1;
            RaceProf2.ItemsSource = tProf2;
            UpdateClassSkillsComboBoxesItems();
        }

        private void ClassSkillChange(object sender, SelectionChangedEventArgs e)
        {
            UpdateClassSkillsComboBoxesItems();
        }

        private void UpdateEnabledClassSkillsComboBoxes()
        {
            if (selectedClass is null)
            {
                ClassSkillsLabel.Visibility = Visibility.Hidden;
                ClassSkill1.IsEnabled = false;
                ClassSkill2.IsEnabled = false;
                ClassSkill3.IsEnabled = false;
                ClassSkill4.IsEnabled = false;
                ClassSkill1.Visibility = Visibility.Hidden;
                ClassSkill2.Visibility = Visibility.Hidden;
                ClassSkill3.Visibility = Visibility.Hidden;
                ClassSkill4.Visibility = Visibility.Hidden;
                ClassSkill1.SelectedIndex = -1;
                ClassSkill2.SelectedIndex = -1;
                ClassSkill3.SelectedIndex = -1;
                ClassSkill4.SelectedIndex = -1;
                return;
            }
            ClassSkillsLabel.Visibility = Visibility.Visible;
            switch (selectedClass.ClassSkillsOptions.Key)
            {
                case 2:
                    ClassSkill1.IsEnabled = true;
                    ClassSkill2.IsEnabled = true;
                    ClassSkill3.IsEnabled = false;
                    ClassSkill4.IsEnabled = false;
                    ClassSkill1.Visibility = Visibility.Visible;
                    ClassSkill2.Visibility = Visibility.Visible;
                    ClassSkill3.Visibility = Visibility.Hidden;
                    ClassSkill4.Visibility = Visibility.Hidden;
                    ClassSkill3.SelectedIndex = -1;
                    ClassSkill4.SelectedIndex = -1;
                    break;
                case 3:
                    ClassSkill1.IsEnabled = true;
                    ClassSkill2.IsEnabled = true;
                    ClassSkill3.IsEnabled = true;
                    ClassSkill4.IsEnabled = false;
                    ClassSkill1.Visibility = Visibility.Visible;
                    ClassSkill2.Visibility = Visibility.Visible;
                    ClassSkill3.Visibility = Visibility.Visible;
                    ClassSkill4.Visibility = Visibility.Hidden;
                    ClassSkill4.SelectedIndex = -1;
                    break;
                case 4:
                    ClassSkill1.IsEnabled = true;
                    ClassSkill2.IsEnabled = true;
                    ClassSkill3.IsEnabled = true;
                    ClassSkill4.IsEnabled = true;
                    ClassSkill1.Visibility = Visibility.Visible;
                    ClassSkill2.Visibility = Visibility.Visible;
                    ClassSkill3.Visibility = Visibility.Visible;
                    ClassSkill4.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void UpdateClassSkillsComboBoxesItems()
        {
            if (lCharacterClass.SelectedItem is null)
                return;
            HashSet<string> tSkills = new HashSet<string>(selectedClass.ClassSkillsOptions.Value);
            if(!(selectedRace is null))
            {
                tSkills.ExceptWith(selectedRace.RaceProficiencies);
                tSkills.ExceptWith(selectedRaceProfs);
            }
            HashSet<string> tSkills1 = new HashSet<string>(tSkills);
            HashSet<string> tSkills2 = new HashSet<string>(tSkills);
            HashSet<string> tSkills3 = new HashSet<string>(tSkills);
            HashSet<string> tSkills4 = new HashSet<string>(tSkills);
            selectedClassProfs.Clear();
            if (!(ClassSkill1.SelectedItem is null))
            {
                selectedClassProfs.Add(ClassSkill1.SelectedItem.ToString());
                tSkills2.Remove(ClassSkill1.SelectedItem.ToString());
                tSkills3.Remove(ClassSkill1.SelectedItem.ToString());
                tSkills4.Remove(ClassSkill1.SelectedItem.ToString());
            }
            if (!(ClassSkill2.SelectedItem is null))
            {
                selectedClassProfs.Add(ClassSkill2.SelectedItem.ToString());
                tSkills1.Remove(ClassSkill2.SelectedValue.ToString());
                tSkills3.Remove(ClassSkill2.SelectedItem.ToString());
                tSkills4.Remove(ClassSkill2.SelectedItem.ToString());
            }
            if (!(ClassSkill3.SelectedItem is null))
            {
                selectedClassProfs.Add(ClassSkill3.SelectedItem.ToString());
                tSkills1.Remove(ClassSkill3.SelectedItem.ToString());
                tSkills2.Remove(ClassSkill3.SelectedItem.ToString());
                tSkills4.Remove(ClassSkill3.SelectedItem.ToString());
            }
            if (!(ClassSkill4.SelectedItem is null))
            {
                selectedClassProfs.Add(ClassSkill4.SelectedItem.ToString());
                tSkills1.Remove(ClassSkill4.SelectedItem.ToString());
                tSkills2.Remove(ClassSkill4.SelectedItem.ToString());
                tSkills3.Remove(ClassSkill4.SelectedItem.ToString());
            }
            ClassSkill1.ItemsSource = tSkills1;
            ClassSkill2.ItemsSource = tSkills2;
            ClassSkill3.ItemsSource = tSkills3;
            ClassSkill4.ItemsSource = tSkills4;
        }

        private void RaceSpecs(object sender, RoutedEventArgs e)
        {
            if (lCharacterRace.SelectedValue is null)
                return;
            string item = (string)lCharacterRace.SelectedValue;
            IRace selectedRace = IRace.FactoryMethod(item);
            MessageBox.Show(selectedRace.ToString());
        }

        private void ClassSpecs(object sender, RoutedEventArgs e)
        {
            if (lCharacterClass.SelectedValue is null)
                return;
            string item = (string)lCharacterClass.SelectedValue;
            IClass selectedClass = IClass.FactoryMethod(item);
            MessageBox.Show(selectedClass.ToString());
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            string err_msg = "Fill in all empty fields.";
            if ((selectedClass is null || selectedRace is null) ||
                    (selectedRace.GetType() == typeof(IRace) || selectedClass.GetType() == typeof(IClass)) ||
                    (ArtisanTools.IsVisible && ArtisanTools.SelectedItem is null) ||
                    (ExtraLanguage.IsVisible && ExtraLanguage.SelectedItem is null) ||
                    (RaceProf1.IsVisible && (RaceProf1.SelectedItem is null || RaceProf2.SelectedItem is null)) ||
                    (ClassSkill1.SelectedItem is null || ClassSkill2.SelectedItem is null) ||
                    (ClassSkill3.IsVisible && ClassSkill3.SelectedItem is null) ||
                    (ClassSkill4.IsVisible && ClassSkill4.SelectedItem is null))
            {
                MessageBox.Show(err_msg);
                return;
            }

            cc.SetRaceAndClass(selectedRace, selectedClass);
            cc.AddProficiency(selectedClassProfs.Union(selectedRaceProfs));
            if (cc.GetPlayerLevel() > 1)
            {
                int ASICount = cc.GreaterLevel();
                if (ASICount > 0)
                {
                    this.NavigationService.Navigate(new CharacterGeneratorASIPage(cc, ASICount));
                    return;
                }
            }
            // navigate to final screen
            cc.RollStats();
            PlayerSheetWindow playerSheet = new PlayerSheetWindow(cc);
            playerSheet.Show();
            Window window = this.Parent as Window;
            window.Close();
        }

        
    }
}
