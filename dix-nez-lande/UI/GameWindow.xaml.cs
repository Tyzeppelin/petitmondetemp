using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media;
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
            Game_Grid.ShowGridLines = false;
            for (int i = 0; i < size; i++)
            {
                Game_Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30, GridUnitType.Pixel) });
                Game_Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel) });
            }

            initGrid();
            updateUnits();

            game.start();
            this.updateInfoBox();
        }

        private void initGrid()
        {
            Map map = game.map;
            Tile[] tiles = map.tiles;

            var child = Game_Grid.Children;

            for (int i = 0; i < game.map.size; i++)
            {
                for (int j = 0; j < game.map.size; j++)
                {
                    Image im = colorTile(game.map.tiles[i + size * j]);
                    Grid.SetRow(im, i);
                    Grid.SetColumn(im, j);
                    Game_Grid.Children.Add(im);
                }
                Game_Grid.UpdateLayout();
            }
        }

        private Image colorTile(Tile tile)
        {
            Image img = new Image();
            string path;
            switch (tile.getName())
            {
                case "water":
                    path = "water.png";
                    break;
                case "forest":
                    path = "forest.png";
                    break;
                case "plain":
                    path = "plain.png";
                    break;
                case "mountain":
                    path = "mountain.png";
                    break;
                default :
                    path = "water.png";
                    break;
            }
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,,/resources/Textures/Tiles/"+path);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            img.Source = src;

            return img;
        }

        private void updateUnits()
        {
            foreach (Unit u in game.players[0].units)
                {
                    Ellipse e = drawCircle("#aa0000");
                    Grid.SetRow(e, u.pos.x);
                    Grid.SetColumn(e, u.pos.y);
                    Game_Grid.Children.Add(e);
                }
            foreach (Unit u in game.players[0].units)
            {
                Ellipse e = drawCircle("black");
                Grid.SetRow(e, u.pos.x);
                Grid.SetColumn(e, u.pos.y);
                Game_Grid.Children.Add(e);
            }
        }

        private Ellipse drawCircle(string col)
        {
            Ellipse e = new Ellipse() { Height = 20, Width = 20,  };
            RadialGradientBrush brush = new RadialGradientBrush();
            brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString(col), 8));
            e.Fill = brush;
            return e;
        }


        private void updateInfoBox()
        {
           infoBox.Text = "Turn " + (this.game.nbTurn/2) + "/" + (this.turns/2)+". It's " + this.game.current.name + " turn.";
        }   

        private void switchPlayers()
        {
            this.game.endTurn();
            this.updateUnits();
            this.updateInfoBox();
        }

        private void endGame()
        {
            Player winner = this.game.whoWin();
            MessageBox.Show(winner.name + " wins. Gratz!");
            Window old = App.Current.MainWindow;
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
            old.Close();
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
            this.updateUnits();
        }

        private void PopHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Useful Help");
        }
    }
}
