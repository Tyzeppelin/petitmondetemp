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

namespace UniversImaginaire
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MediaPlayer MediaPlayer { get; set; }
        private static String PATH;
        public MainWindow()
        {
            InitializeComponent();
            this.MediaPlayer = new MediaPlayer();
            PATH = System.Environment.CurrentDirectory;
            PATH = PATH.Replace(@"\Debug", @"\UniversImaginaire\Resources");
            PATH = PATH.Replace(@"\Release", @"\UniversImaginaire\Resources");
        }

        private void Doge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Music_start(object sender, RoutedEventArgs e)
        {
            this.MediaPlayer.Volume = 0.4;
            this.MediaPlayer.Open(new Uri(PATH+@"\music.mp3"));
            this.MediaPlayer.Play();
            Console.WriteLine("Let's yhe music play"); 
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
