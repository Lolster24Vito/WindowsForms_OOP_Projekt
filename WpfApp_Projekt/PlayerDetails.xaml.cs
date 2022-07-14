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
using System.Windows.Shapes;

namespace WpfApp_Projekt
{
    /// <summary>
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Window
    {
       private  Player player;
        private List<TeamEvent> events;
        public PlayerDetails(Player player, List<TeamEvent> events)
        {
            InitializeComponent();
            this.player = player;
            this.events = events;
            SetValues();
        }

        private void SetValues()
        {
            if (player == null && events.Count > 0)
                return;

            
            lblName.Text=player.Name;
            lblShirtNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position.ToString();
            if (player.Captain)
            {
                lblCaptain.Visibility = Visibility.Visible;
            }
            else
            {
                lblCaptain.Visibility = Visibility.Collapsed;

            }
            InitLoadImage();

            int yellowCards = 0;
            int goals = 0;
            foreach (var teamEvent in events)
            {
                if (teamEvent.TypeOfEvent== "yellow-card"&&teamEvent.Player==player.Name)
                {
                    yellowCards++;
                }
                if (teamEvent.TypeOfEvent == "goal" && teamEvent.Player == player.Name)
                {
                    goals++;
                }
            }
            player.NumberOfGoals = goals;
            player.NumberOfYellowCards = yellowCards;
            lblNumberOfGoals.Text = goals.ToString();
            lblNumberOfYellowCards.Text = yellowCards.ToString();

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
    }
}
