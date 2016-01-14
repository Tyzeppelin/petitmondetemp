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
using dix_nez_lande;
using dix_nez_lande.Implem;


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

            GameBuilder gb = GameBuilder.create();

            gb.player1(this.P1Name.Text, (string)((ListBoxItem)this.P1Race.SelectedValue).Content);
            gb.player2(this.P2Name.Text, (string)((ListBoxItem)this.P2Race.SelectedValue).Content);

            int sm = GameBuilder.LitMap;

            if ((string)((ListBoxItem)this.Board.SelectedValue).Tag == "0")
            { sm = GameBuilder.LitMap; }
            else if ((string)((ListBoxItem)this.Board.SelectedValue).Tag == "1")
            { sm = GameBuilder.MidMap; }
            else if ((string)((ListBoxItem)this.Board.SelectedValue).Tag == "2")
            { sm = GameBuilder.BigMap; }
            gb.board(sm);
            Game gamu = gb.build();

            Window old = App.Current.MainWindow;
            GameWindow megastrat = new GameWindow(gamu, this.allowCheat.IsChecked.Value);
            App.Current.MainWindow = megastrat;
            App.Current.MainWindow.Show();
            old.Close();
        }
        private void PopHelp(object sender, RoutedEventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\resources\raceHelp.txt");
            string text = "";
            foreach (string line in lines)
            {
                text += "\n" + line;
            }
            MessageBox.Show(text);
        }
    }
}
