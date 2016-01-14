using System;
using System.Collections.Generic;
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
        private Unit movingUnit;
        private int ptsPlayer1 = 0;
        private int ptsPlayer2 = 0;

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

            updateGrid();

            game.start();
            this.updateInfoBox();
        }

        private void updateGrid()
        {
            Map map = game.map;
            Tile[] tiles = map.tiles;
            var child = Game_Grid.Children;

            List<UIElement> deletable = new List<UIElement>();
            foreach (UIElement c in child)
                if (c is Image)
                    deletable.Add(c);
            foreach (UIElement e in deletable)
                Game_Grid.Children.Remove(e);

            for (int i = 0; i < game.map.size; i++)
            {
                for (int j = 0; j < game.map.size; j++)
                {
                    Image im = colorTile(game.map.tiles[i + size * j]);
                    Grid.SetRow(im, j);
                    Grid.SetColumn(im, i);
                    im.MouseLeftButtonDown += Tile_Left_Clicked;
                    im.MouseRightButtonDown += Tile_Right_Clicked;
                    Game_Grid.Children.Add(im);
                }
            }

            foreach (Unit u in game.players[0].units)
            {
                if (u.hp > 0) {
                    Image e = getImagePlayer(1);
                    e.MouseLeftButtonDown += Tile_Left_Clicked;
                    e.MouseRightButtonDown += Tile_Right_Clicked;
                    Grid.SetRow(e, u.pos.y);
                    Grid.SetColumn(e, u.pos.x);
                    Game_Grid.Children.Add(e);
                }
            }
            foreach (Unit u in game.players[1].units)
            {
                if (u.hp > 0)
                {
                    Image e = getImagePlayer(2);
                    e.MouseLeftButtonDown += Tile_Left_Clicked;
                    e.MouseRightButtonDown += Tile_Right_Clicked;
                    Grid.SetRow(e, u.pos.y);
                    Grid.SetColumn(e, u.pos.x);
                    Game_Grid.Children.Add(e);
                }
            }

            Game_Grid.UpdateLayout();
            printPoints();
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
                default:
                    path = "water.png";
                    break;
            }
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,,/resources/Textures/Tiles/" + path);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            img.Source = src;

            return img;
        }

        private Image getImagePlayer(int i)
        {
            Image img = new Image();
            string path;
            if (i == 1)
            {
                path = "Player1.png";
            }
            else
            {
                path = "Player2.png";
            }
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("pack://application:,,,/resources/Textures/Players/" + path);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            img.Source = src;

            return img;
        }

        private void updateInfoBox()
        {
            infoBox.Text = "Turn " + (this.game.nbTurn / 2) + "/" + (this.turns / 2) + ". It's " + this.game.current.name + " turn.";
        }

        private void switchPlayers()
        {
            foreach (Player p in game.players)
                foreach (Unit u in p.units)
                    u.aBouge = false;
            if (game.current.name == game.players[0].name)
            {
                ptsPlayer1 += game.map.getPoints(game.current);
            }
            else
            {
                ptsPlayer2 += game.map.getPoints(game.current);
            }
            this.game.endTurn();
            this.updateGrid();
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
            if (this.game.nbTurn == 0)
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
            if (game.nbTurn != turns)
            {
                MessageBox.Show("aze"+game.nbTurn);
                this.game.undo();
                this.updateInfoBox();
                this.updateGrid();
            }
        }

        private void PopHelp(object sender, RoutedEventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\resources\help.txt");
            string text = "";
            foreach (string line in lines)
            {
                text += "\n" + line;
            }
            MessageBox.Show(text);
        }

        // select an unit
        private void Tile_Left_Clicked(object sender, RoutedEventArgs e)
        {
            if (sender.GetType().Equals(typeof(Image)))
            {
                Image img = (Image)sender;

                int co = Grid.GetColumn(img);
                int ro = Grid.GetRow(img);

                movingUnit = game.current.getUnit(co, ro);
                Player proprio = game.current;
                Unit clickedUnit = game.current.getUnit(co, ro);
                if (clickedUnit == null)
                {
                    if (game.current.name == game.players[0].name)
                    {
                        clickedUnit = game.players[1].getUnit(co, ro);
                        proprio = game.players[1];
                    }
                    else
                    {
                        clickedUnit = game.players[0].getUnit(co, ro);
                        proprio = game.players[0];
                    }
                }
                printSelectedUnit(clickedUnit, proprio);

                //updateUnits();
                e.Handled = true;
            }
        }

        // move/attack if possible
        private void Tile_Right_Clicked(object sender, RoutedEventArgs e)
        {
            if (sender.GetType().Equals(typeof(Image)))
            {
                Image img = (Image)sender;

                int co = Grid.GetColumn(img);
                int ro = Grid.GetRow(img);

                if (movingUnit != null)
                {
                    int i = game.current == game.players[0] ? 1 : 0;
                    Unit u = game.players[i].getUnit(co, ro);
                    Position p = PositionImpl.getPosition(co, ro);
                    if (u == null)
                    {
                        game.map.moveTo(movingUnit, p);

                    }
                    else
                    {
                        bool victory = game.map.attack(movingUnit, p);
                        if (victory)
                        {
                            game.map.moveTo(movingUnit, p);
                        }
                        else
                        {
                            if (!movingUnit.isAlive())
                            {
                                game.current.units.Remove(movingUnit);
                            }
                        }
                    }
                }
                printSelectedUnit(movingUnit, game.current);
                updateGrid();

                e.Handled = true;
            }
        }

        private void printSelectedUnit(Unit u, Player proprio)
        {
            if (u != null && u.hp > 0)
            {
                name_textBloc.Text = "Name : " + u.name + " of " + proprio.name;
                race_textBloc.Text = "Race : " + u.race.name;
                life_textBloc.Text = "Life : " + u.hp;
                attack_textBloc.Text = "Attack : " + u.atk;
                defense_textBloc.Text = "Defense : " + u.def;
                move_textBloc.Text = "Move points : ";
                if (u.aBouge) { move_textBloc.Text += 0; }
                else { move_textBloc.Text += u.mov; }
            }
            else
            {
                name_textBloc.Text = "";
                race_textBloc.Text = "";
                life_textBloc.Text = "";
                attack_textBloc.Text = "";
                defense_textBloc.Text = "";
                move_textBloc.Text = "";
                move_textBloc.Text = "";
            }
        }

        private void printPoints()
        {
            player1_pt.Text = game.players[0].name + " : " + ptsPlayer1;
            player2_pt.Text = game.players[1].name + " : " + ptsPlayer2;
        }

        private void RestartGame(object sender, RoutedEventArgs e)
        {
            GameBuilder gb = GameBuilder.create();

            gb.player1(game.players[0].name, game.players[0].race.name);
            gb.player2(game.players[1].name, game.players[1].race.name);

            int sm = game.map.size;
            gb.board(sm);
            Game gamu = gb.build();

            Window old = App.Current.MainWindow;
            GameWindow megastrat = new GameWindow(gamu, isCheatAllowed);
            App.Current.MainWindow = megastrat;
            App.Current.MainWindow.Show();
            old.Close();
        }
    }
}
