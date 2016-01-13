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

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour CharacterSelection.xaml
    /// </summary>
    public partial class CharacterSelection : Page
    {
        public CharacterSelection()
        {
            InitializeComponent();
        }

        private void playGame(object sender, RoutedEventArgs e)
        {
            Window old = App.Current.MainWindow;
            App.Current.MainWindow = new GameWindow();
            old.Close();
            App.Current.MainWindow.Show();
            MessageBox.Show("~~TUTURU~~");
        }
    }
}
