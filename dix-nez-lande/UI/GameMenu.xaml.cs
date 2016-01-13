﻿using System;
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
            // CharacterSelection cs = new CharacterSelection();
            this.NavigationService.Source = new System.Uri("/GameSet.xaml", System.UriKind.Relative);
            MessageBox.Show("TOUHOU");
        }
        private void optionButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("plop");
        }

        private void exitButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
