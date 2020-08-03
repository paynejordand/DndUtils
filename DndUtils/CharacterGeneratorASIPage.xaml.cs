using DndUtils;
using DndUtils.CharacterGenerator;
using DndUtils.CharacterGenerator.Feat;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CharacterGeneratorASIPage.xaml
    /// </summary>
    public partial class CharacterGeneratorASIPage : Page
    {
        CharacterController cc;
        List<string> featOptions;
        HashSet<ComboBox> asiComboBoxes = new HashSet<ComboBox>();
        HashSet<ComboBox> featASIComboBoxes = new HashSet<ComboBox>();
        HashSet<ComboBox> featComboBoxes = new HashSet<ComboBox>();
        HashSet<StackPanel> asiPanels;
        Dictionary<string, int> tempScores = new Dictionary<string, int>();

        public CharacterGeneratorASIPage(object obj, int count)
        {
            InitializeComponent();
            cc = (CharacterController)obj;
            cc.RollStats();
            UpdateText();
            featOptions = cc.FeatOptions();
            switch (count)
            {
                case 1:
                    asiPanels = new HashSet<StackPanel>()
                    {
                        ASI_1,
                    };
                    break;
                case 2:
                    asiPanels = new HashSet<StackPanel>()
                    {
                        ASI_1,
                        ASI_2
                    };
                    break;
                case 3:
                    asiPanels = new HashSet<StackPanel>()
                    {
                        ASI_1,
                        ASI_2,
                        ASI_3,
                    };
                    break;
                case 4:
                    asiPanels = new HashSet<StackPanel>()
                    {
                        ASI_1,
                        ASI_2,
                        ASI_3,
                        ASI_4,
                    };
                    break;
                case 5:
                    asiPanels = new HashSet<StackPanel>()
                    {
                        ASI_1,
                        ASI_2,
                        ASI_3,
                        ASI_4,
                        ASI_5,
                    };
                    break;
                case 6:
                    asiPanels = new HashSet<StackPanel>()
                    {
                        ASI_1,
                        ASI_2,
                        ASI_3,
                        ASI_4,
                        ASI_5,
                        ASI_6,
                    };
                    break;
            }
            foreach(StackPanel sp in asiPanels)
            {
                sp.IsEnabled = true;
                sp.Visibility = Visibility.Visible;
            }
        }

        private void UpdateText()
        {
            tempScores = new Dictionary<string, int>(cc.GetStats());
            string output = "";
            foreach (KeyValuePair<string, int> kv in cc.GetStats())
            {
                foreach(ComboBox cb in asiComboBoxes.Union(featASIComboBoxes))
                {
                    if (cb.SelectedItem is null)
                        break;
                    if (cb.SelectedItem.ToString().Equals(kv.Key))
                        tempScores[kv.Key] += 1;
                }
                output += $"{kv.Key} -- {tempScores[kv.Key]}\n";
            }
            CharacterScores.Text = output;
        }

        private void ASI_ComboBoxItems()
        {
            foreach(ComboBox cb in asiComboBoxes)
            {
                HashSet<string> options = new HashSet<string>();
                foreach (KeyValuePair<string, int> kv in tempScores)
                {
                    if (kv.Value < 20)
                        options.Add(kv.Key);
                    else
                        options.Remove(kv.Key);
                }
                if (!(cb.SelectedItem is null))
                {
                    options.Add(cb.SelectedItem.ToString());
                }
                cb.ItemsSource = options;
            }
            foreach(ComboBox cb in featASIComboBoxes)
            {
                StackPanel featStackPanel = (cb.Parent as StackPanel).Parent as StackPanel;
                IFeat feat = IFeat.FactoryMethod((featStackPanel.Children[1] as ComboBox).SelectedItem.ToString());
                HashSet<string> options = new HashSet<string>(feat.FeatAbilityScoreEffect);
                foreach(string item in cb.Items)
                {
                    if (!(cb.SelectedItem is null))
                        if (cb.SelectedItem.Equals(item))
                            break;
                    if (tempScores[item] >= 20)
                        options.Remove(item);
                }
                cb.ItemsSource = options;
            }
        }

        private void Feat_ComboBoxItems()
        {
            foreach(ComboBox cb in featComboBoxes)
            {
                List<string> tFeats = new List<string>(featOptions);
                foreach(ComboBox comboBox in featComboBoxes)
                {
                    if (comboBox.Equals(cb))
                        break;
                    if (!(comboBox.SelectedItem is null))
                        tFeats.Remove(comboBox.SelectedItem.ToString());
                }
                cb.ItemsSource = tFeats;
            }
        }

        private void ASI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateText();
            ASI_ComboBoxItems();
        }

        private void Option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox senderComboBox = sender as ComboBox;
            StackPanel featStackPanel = (senderComboBox.Parent as StackPanel).Children[2] as StackPanel;
            StackPanel asiStackPanel = (senderComboBox.Parent as StackPanel).Children[3] as StackPanel;
            // Feat
            if (senderComboBox.SelectedIndex.Equals(0))
            {
                featStackPanel.IsEnabled = true;
                featStackPanel.Visibility = Visibility.Visible;
                featComboBoxes.Add(featStackPanel.Children[1] as ComboBox);
                Feat_ComboBoxItems();

                asiStackPanel.Visibility = Visibility.Hidden;
                asiStackPanel.IsEnabled = false;
                (asiStackPanel.Children[1] as ComboBox).SelectedIndex = -1;
                (asiStackPanel.Children[2] as ComboBox).SelectedIndex = -1;
                asiComboBoxes.Remove(asiStackPanel.Children[1] as ComboBox);
                asiComboBoxes.Remove(asiStackPanel.Children[2] as ComboBox);
                ASI_ComboBoxItems();
            }
            // ASI
            else if (senderComboBox.SelectedIndex.Equals(1))
            {
                featStackPanel.IsEnabled = false;
                featStackPanel.Visibility = Visibility.Hidden;
                featComboBoxes.Remove(featStackPanel.Children[1] as ComboBox);
                featASIComboBoxes.Remove((featStackPanel.Children[3] as StackPanel).Children[1] as ComboBox);
                (featStackPanel.Children[1] as ComboBox).SelectedIndex = -1;
                ((featStackPanel.Children[3] as StackPanel).Children[1] as ComboBox).SelectedIndex = -1;
                Feat_ComboBoxItems();

                asiStackPanel.IsEnabled = true;
                asiStackPanel.Visibility = Visibility.Visible;
                asiComboBoxes.Add(asiStackPanel.Children[1] as ComboBox);
                asiComboBoxes.Add(asiStackPanel.Children[2] as ComboBox);
                ASI_ComboBoxItems();
            }
            UpdateText();
        }

        private void ASI_Feat_LM(object sender, RoutedEventArgs e)
        {
            StackPanel featStackPanel = (sender as Button).Parent as StackPanel;
            ComboBox featSelectionComboBox = featStackPanel.Children[1] as ComboBox;

            if (featSelectionComboBox.SelectedItem is null)
                return;
            if (featSelectionComboBox.SelectedItem.Equals(null))
                return;
            IFeat feat = IFeat.FactoryMethod(featSelectionComboBox.SelectedItem.ToString());
            MessageBox.Show(feat.ToString());
        }

        private void Feat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox featSelection = sender as ComboBox;
            StackPanel featStackPanel = featSelection.Parent as StackPanel;
            StackPanel featASIStackPanel = featStackPanel.Children[3] as StackPanel;

            if (featSelection.SelectedItem is null)
                return;
            if (featSelection.SelectedItem.Equals(null))
                return;

            IFeat feat = IFeat.FactoryMethod(featSelection.SelectedItem.ToString());
            if(feat.FeatAbilityScoreEffect.Count > 0)
            {
                featASIComboBoxes.Add(featASIStackPanel.Children[1] as ComboBox);
                HashSet<string> ASChecker = new HashSet<string>(feat.FeatAbilityScoreEffect);
                HashSet<string> ASOptions = new HashSet<string>();
                foreach (string ability in ASChecker)
                {
                    if (tempScores[ability] < 20)
                        ASOptions.Add(ability);
                }
                if(ASChecker.Count > 0)
                {
                    featASIStackPanel.IsEnabled = true;
                    featASIStackPanel.Visibility = Visibility.Visible;
                    (featASIStackPanel.Children[1] as ComboBox).ItemsSource = ASOptions;
                }
            }
            else
            {
                featASIComboBoxes.Remove(featASIStackPanel.Children[1] as ComboBox);
                featASIStackPanel.IsEnabled = false;
                featASIStackPanel.Visibility = Visibility.Hidden;
                (featASIStackPanel.Children[1] as ComboBox).SelectedIndex = -1;
            }
            UpdateText();
            Feat_ComboBoxItems();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string err_msg = "Fill in all empty fields";
            foreach(StackPanel sp in asiPanels)
            {
                if (sp.Visibility.Equals(Visibility.Hidden))
                    break;
                if((sp.Children[1] as ComboBox).SelectedItem is null)
                {
                    MessageBox.Show(err_msg);
                    return;
                }
            }
            foreach (ComboBox cb in asiComboBoxes.Union(featComboBoxes.Union(featASIComboBoxes)))
            {
                if(cb.SelectedItem is null)
                {
                    MessageBox.Show(err_msg);
                    return;
                }
                else if (cb.SelectedItem.Equals(null))
                {
                    MessageBox.Show(err_msg);
                    return;
                }
            }

            cc.SetStats(tempScores);

            HashSet<string> selectedFeats = new HashSet<string>();
            foreach (ComboBox cb in featComboBoxes)
            {
                selectedFeats.Add(cb.SelectedItem.ToString());
            }
            cc.AddFeat(selectedFeats);

            PlayerSheetWindow playerSheet = new PlayerSheetWindow(cc);
            playerSheet.Show();
            Window window = this.Parent as Window;
            window.Close();
        }
    }
}
