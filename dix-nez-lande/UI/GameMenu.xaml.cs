using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour GameMenu.xaml
    /// </summary>
    public partial class GameMenu : Page
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        private void newGame(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Source = new System.Uri("/CharacterSelection.xaml", System.UriKind.Relative);
        }
        private void optionButton(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo notepadStartInfo = new ProcessStartInfo("notepad.exe ./README.md");
            Process notepad = new Process();
            notepad.StartInfo = notepadStartInfo;
            notepad.Start();
        }

        private void exitButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
