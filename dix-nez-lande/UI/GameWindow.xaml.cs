using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using dix_nez_lande;
using dix_nez_lande.Implem;

namespace UI
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        private Game game;
        private int size;
        private int turns;
        private bool isCheatAllowed;

        public GameWindow()
        {
            InitializeComponent();
        }

        public GameWindow(Game g, bool cheat)
        {
            InitializeComponent();
            this.turns = g.nbTurn;
            this.size = g.map.size;
            this.isCheatAllowed = cheat;
            if (cheat)
            {
                this.Undo.IsEnabled = true;
            }

            game = g;

            int tileSize = size * 30;

            Game_Grid.Width = tileSize;
            Game_Grid.Height = tileSize;
            Game_Grid.HorizontalAlignment = HorizontalAlignment.Center;
            Game_Grid.VerticalAlignment = VerticalAlignment.Center;
            for (int i = 0; i < size; i++)
            {
                Game_Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30, GridUnitType.Pixel) });
                Game_Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel) });
            }

            game.start();
            this.updateInfoBox();
        }

        private void updateGrid()
        {
            Map map = game.map;
            Tile[] tiles = map.tiles;
            
            var child = Game_Grid.Children;
            foreach(UIElement ce in child)
            {
                int row = Grid.GetRow(ce);
                int column = Grid.GetColumn(ce);
                //tiles[i + (j * size)];
               // ce.

            }
                   // Game_Grid.Children.Add(image);
        }

        private Image colorTile(Tile tile)
        {
            Image img = new Image();
            string path;
            switch (tile.getName())
            {
                case "water":
                    path = ".\resources\\TilesTextures\\water.png";
                    break;
                case "forest":
                    path = ".\\resources\\TilesTextures\\forest.png";
                    break;
                case "plain":
                    path = ".\\resources\\TilesTextures\\plain.png";
                    break;
                case "mountain":
                    path = ".\\resources\\TilesTextures\\mountain.png";
                    break;
                default :
                    path = ".\\resources\\TilesTextures\\water.png";
                    break;
            }
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new System.Uri(path, UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            img.Source = src;

            return img;
        }

        private void updateInfoBox()
        {
           infoBox.Text = "Turn " + (this.game.nbTurn/2) + "/" + (this.turns/2)+". It's " + this.game.current.name + " turn.";
        }   

        private void switchPlayers()
        {
            this.game.endTurn();
            this.updateInfoBox();
        }

        private void endGame()
        {
            Player winner = this.game.whoWin();
            MessageBox.Show(winner.name + " wins. Gratz!");
        }

        private void endTurn(object sender, RoutedEventArgs e)
        {
            if(this.game.nbTurn == 0)
            {
                this.endGame();
            }
            else
            {
                this.switchPlayers();
            }  
        }

        private void showHint(object sender, RoutedEventArgs e)
        {
            this.game.suggest();
            MessageBox.Show("this button will disappear");
        }

        private void Cheat(object sender, RoutedEventArgs e)
        {
            this.game.undo();
            this.updateInfoBox();
            this.updateGrid();
            this.updateGrid();
        }

        private void PopHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Useful Help");
        }
    }
}
