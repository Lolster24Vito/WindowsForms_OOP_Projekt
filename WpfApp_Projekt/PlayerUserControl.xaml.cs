using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp_Projekt
{
    /// <summary>
    /// Interaction logic for PlayerUserControl.xaml
    /// </summary>
    public partial class PlayerUserControl : UserControl
    {
        private Player player;
        public Player Player { get => player; set 
            {
            player = value;
                ChangeValues();
            } }
        public List<TeamEvent> MatchEvents { get; set; }

        private void ChangeValues()
        {
           name.Text = Player.Name;
            shirtNumber.Text = Player.ShirtNumber.ToString();
            InitLoadImage();
        }

        public PlayerUserControl(Player play)
        {
            InitializeComponent();
            Player = play;
            InitLoadImage();
        }

        private void InitLoadImage()
        {
            if (player != null && player.PicturePath != null && player.PicturePath != "" && File.Exists(player.PicturePath))
                playerPicture.Source = new BitmapImage(new Uri(player.PicturePath)); 
            else
            {
                playerPicture.Source = new BitmapImage(new Uri("Resources/profile icon.jpg", UriKind.Relative));

            }
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //clicked show to give it a shot 
           new PlayerDetails(player, MatchEvents).ShowDialog();
          //  MessageBox.Show("Clicked on" + player.Name);
        }
    }
}
