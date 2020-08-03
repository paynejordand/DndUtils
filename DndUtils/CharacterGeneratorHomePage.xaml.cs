using DndUtils;
using DndUtils.CharacterGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for CharacterGeneratorHome.xaml
    /// </summary>
    public partial class CharacterGeneratorHome : Page
    {

        public CharacterGeneratorHome()
        {
            InitializeComponent();
        }

        private void RandomCharacter(object sender, RoutedEventArgs e)
        {
            string characterName = lCharacterName.Text;
            bool validLevel = int.TryParse(lCharacterLevel.Text, out int characterLevel);
            if (characterLevel < 1 || characterLevel > 20)
                validLevel = false;

            if (validLevel && !string.IsNullOrEmpty(characterName))
            {
                CharacterController cc = new CharacterController();
                cc.RandomCharacter(characterLevel, characterName);
                PlayerSheetWindow playerSheet = new PlayerSheetWindow(cc);
                playerSheet.Show();
            }

        }
        
        private void CustomCharacter(object sender, RoutedEventArgs e)
        {
            string characterName = lCharacterName.Text;
            bool validLevel = int.TryParse(lCharacterLevel.Text, out int characterLevel);
            if (characterLevel < 1 || characterLevel > 20)
                validLevel = false;

            if (validLevel && !string.IsNullOrEmpty(characterName))
            {
                CharacterController cc = new CharacterController();
                cc.SetNameAndLevel(characterName, characterLevel);

                this.NavigationService.Navigate(new CharacterGeneratorCustomCharacterPage(cc));
            }
        }
    }
}
