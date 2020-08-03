using DndUtils;
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
    /// Interaction logic for DndUtilsHome.xaml
    /// </summary>
    public partial class DndUtilsHome : Page
    {
        public DndUtilsHome()
        {
            InitializeComponent();
        }

        private void CharacterGenerator(object sender, RoutedEventArgs e)
        {
            CharacterGeneratorMain w = new CharacterGeneratorMain();
            w.Show();
        }
    }
}
