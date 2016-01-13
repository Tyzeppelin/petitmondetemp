using System.Windows;
using System.Windows.Controls;
using dix_nez_lande;
using dix_nez_lande.Implem;

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            int size = 16;
            GameBuilder gb = GameBuilder.create();
            gb.board(size);
            gb.player1("Malabar", "human");
            gb.player2("Tyzeplin", "elf");
            Game game = gb.build();

            int tileSize = size * 30;

            Grid myGrid = new Grid();
            Game_Grid.Width = tileSize;
            Game_Grid.Height = tileSize;
            Game_Grid.ShowGridLines = true;
            Game_Grid.HorizontalAlignment = HorizontalAlignment.Center;
            Game_Grid.VerticalAlignment = VerticalAlignment.Center;
            for (int i = 0; i < size; i++)
            {
                Game_Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(tileSize, GridUnitType.Pixel) });
                Game_Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(tileSize, GridUnitType.Pixel) });
            }
        }
    }
}
