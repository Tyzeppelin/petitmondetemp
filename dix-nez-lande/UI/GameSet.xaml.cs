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
    /// Logique d'interaction pour GameSet.xaml
    /// </summary>
    public partial class GameSet : Page
    {
        public GameSet()
        {
            InitializeComponent();
            int size = 16;
            GameBuilder gb = GameBuilder.create();
            gb.board(size);
            gb.player1("Malabar", "human");
            gb.player2("Tyzeplin", "elf");
            Game game = gb.build();

            Grid myGrid = new Grid();
            int tileSize = size * 30;
            myGrid.Width = tileSize;
            myGrid.Height = tileSize;
            myGrid.ShowGridLines = true;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            for (int i = 0; i < size; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colDef);
                RowDefinition rowDef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef);
            }
        }
    }
}
