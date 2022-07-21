using DAL;
using DAL.Models;
using DAL.REPO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IRepoJSONDeserialize repo = RepositoryFactory.GetRepository();
        private UserSettings settings;

        private const string USER_SETTINGS_PATH = DAL.Constants.ApiConstants.USER_SETTINGS_PATH;
       
       
        private string matchesEndpoint = "";
        private string matchesLocalEndpoint = "";


        private string teamsEndpoint = "";
        private string teamsLocalEndpoint = "";

        private string selectedCountryCode;
        private string selectedEnemyCountryCode;



        private List<MatchesJson> AllTeamMatches;
        private List<Team> TeamPlayed=new List<Team>();
        private List<Player> playersWithPictures = new List<Player>();
        private List<Player> playersLeft = new List<Player>();
        private List<Player> playersRight = new List<Player>();




        private MatchesJson selectedMatch;
        private List<TeamEvent> lTeamEvents;
        private List<TeamEvent> rTeamEvents;
        public MainWindow()
        {
            CheckAndApplySettingsAsync();
            SetCulture(settings.LanguageCode);
            InitializeComponent();
            if (settings != null && settings.Resolution != null)
            {

                this.Height = settings.Resolution.Y;
                this.Width = settings.Resolution.X;
                if(settings.IsFullscreen)
                this.WindowState = WindowState.Maximized;
                else this.WindowState=WindowState.Normal;
            }
            Init();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }

        private void Init()
        {
            try
            {
                LoadPlayerPicturesAsync();
                LoadFavoriteTeam();
                FillLeftCombobox(teamsEndpoint,teamsLocalEndpoint);
                cbTeamR.ItemsSource = null;
                cbTeamR.Items.Clear();

            }
            catch (Exception)
            {

                throw;
            }
           

        }
        private void SaveFavoriteTeam(string selectedCountryCode)
        {
            FileRepo.SaveToFile(selectedCountryCode, DAL.Constants.ApiConstants.USER_FAVORITE_TEAM);
        }

        private async void FillLeftCombobox(string endpoint,string localEndpoint)
        {
            MyProgressBar.Visibility = Visibility.Visible;
            List<TeamModelVersion> teams = new List<TeamModelVersion>();
            try
            {
                teams = await repo.GetTeamsOnline(endpoint);
            }
            catch (Exception)
            {

                teams = await repo.GetTeamsOffline(localEndpoint);
            }
            if (teams.Count == 0) return;
            int selectedIndexFromFile = 0;
             int counter = 0;
             foreach (var t in teams)
             {
                 if (t.FifaCode == selectedCountryCode.Trim())
                 {
                     selectedIndexFromFile = counter;
                     break;
                 }
                 counter++;
             }
            cbTeamL.ItemsSource = null;
            cbTeamL.ItemsSource = teams;
            cbTeamL.SelectedIndex = selectedIndexFromFile;

            MyProgressBar.Visibility = Visibility.Collapsed;



        }
        private async void LoadFavoriteTeam()
        {

            try
            {
                selectedCountryCode = await FileRepo.ReadFromFile(DAL.Constants.ApiConstants.USER_FAVORITE_TEAM);
                selectedCountryCode = selectedCountryCode.Trim();
            }
            catch (Exception)
            {
                throw;
            }

        }
        private async void CheckAndApplySettingsAsync()
        {

            string fileLines = await FileRepo.ReadFromFile(USER_SETTINGS_PATH);
            UserSettings oldSettings=null;
            if (settings != null)
            {
                oldSettings = settings;
            }
            
            settings = UserSettings.ParseFromString(fileLines);



            if (settings == null || settings.LanguageCode == null || settings.ChampionshipGroup == null)
            {
                new UserSettingsWindow().ShowDialog();
            }
            if (settings == null || settings.LanguageCode == null || settings.ChampionshipGroup == null)
            {

                string fileLiness = await FileRepo.ReadFromFile(USER_SETTINGS_PATH);
                settings = UserSettings.ParseFromString(fileLiness);
            }


            if (settings.ChampionshipGroup == ChampionshipType.Male)
            {
                matchesEndpoint = DAL.Constants.ApiConstants.MALE_MATCHES_ENDPOINT;
                matchesLocalEndpoint = DAL.Constants.ApiConstants.MALE_MATCHES_ENDPOINT_LOCAL;
                teamsEndpoint = DAL.Constants.ApiConstants.MALE_TEAMS_ENDPOINT;
                teamsLocalEndpoint = DAL.Constants.ApiConstants.MALE_TEAMS_ENDPOINT_LOCAL;

            }
            if (settings.ChampionshipGroup == ChampionshipType.Female)
            {
                matchesEndpoint = DAL.Constants.ApiConstants.FEMALE_MATCHES_ENDPOINT;
                matchesLocalEndpoint = DAL.Constants.ApiConstants.FEMALE_MATCHES_ENDPOINT_LOCAL;

                teamsEndpoint = DAL.Constants.ApiConstants.FEMALE_TEAMS_ENDPOINT;
                teamsLocalEndpoint = DAL.Constants.ApiConstants.FEMALE_TEAMS_ENDPOINT_LOCAL;


            }

            this.Height = settings.Resolution.Y;
            this.Width = settings.Resolution.X;

            if (settings.IsFullscreen)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;

            if (oldSettings!=null&&settings.LanguageCode != oldSettings.LanguageCode)
            {
                lTeamDetailsButtonText.Text = Properties.Resources.TeamDetails;
                rTeamDetailsButtonText.Text = Properties.Resources.TeamDetails;

            }

        }
        private void SetCulture(string language)
        {

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);

        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            new UserSettingsWindow().ShowDialog();
            CheckAndApplySettingsAsync();
            Init();
        }

        private void cbTeamL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  cbTeamR.SelectedIndex = -1;
            try
            {
                if ((TeamModelVersion)cbTeamL.SelectedValue!= null){
            selectedCountryCode = ((TeamModelVersion) cbTeamL.SelectedValue).FifaCode.Trim();

                }
            }
            catch (Exception)
            {

            }
            cbTeamR.ItemsSource = null;
            cbTeamR.Items.Clear();
            lblMatchResult.Content = "0 - 0";
            try
            {
                SaveFavoriteTeam(selectedCountryCode);
            }
            catch (Exception)
            {

                throw;
            }
            ClearPlayersPanel();

            fillRightComboBox();
        }

        private async void fillRightComboBox()
        {

            MyProgressBar.Visibility = Visibility.Visible;
            try
            {
            AllTeamMatches = await repo.GetMatchesOnline(matchesEndpoint, selectedCountryCode);

            }
            catch (Exception)
            {
                MyProgressBar.Visibility = Visibility.Visible;
                AllTeamMatches = await repo.GetMatchesOffline(matchesLocalEndpoint, selectedCountryCode);

            }

            if (AllTeamMatches == null || AllTeamMatches[0] == null||AllTeamMatches.Count==0)
            {

                MessageBox.Show("An error occuered cannot find matches of country");
                MyProgressBar.Visibility = Visibility.Collapsed;

                return;
            }
            TeamPlayed.Clear();
            foreach (var match in AllTeamMatches)
            {
                if(match.AwayTeam.Code!= selectedCountryCode)
                {
                    TeamPlayed.Add(match.AwayTeam);
                }
                if (match.HomeTeam.Code != selectedCountryCode)
                {
                    TeamPlayed.Add(match.HomeTeam);

                }
            }
            cbTeamR.IsEnabled = true;
            cbTeamR.ItemsSource = TeamPlayed;
            MyProgressBar.Visibility = Visibility.Collapsed;

        }

        private void cbTeamR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTeamR.SelectedValue == null) return;

            selectedEnemyCountryCode = ((Team)cbTeamR.SelectedValue).Code;

            selectedMatch=AllTeamMatches.First(m=>m.AwayTeam.Code==selectedEnemyCountryCode||m.HomeTeam.Code==selectedEnemyCountryCode);
            LoadPlayers();
            long goalsL;
            long goalsR;
            if (selectedMatch.HomeTeam.Code == selectedCountryCode)
            {
                goalsL = selectedMatch.HomeTeam.Goals;
                goalsR = selectedMatch.AwayTeam.Goals;
            }
            else
            {
                goalsR = selectedMatch.HomeTeam.Goals;
                goalsL = selectedMatch.AwayTeam.Goals;
            }
            lblMatchResult.Content = $"{goalsL} - {goalsR}";
            //GET enemy players
            //get hometeam players
        }

        private void LoadPlayers()
        {
            List<StartingEleven> leftPlayers=new List<StartingEleven>();
            List<StartingEleven> rightPlayers=new List<StartingEleven>();
            if (selectedMatch.HomeTeam.Code == selectedCountryCode)
            {
                leftPlayers=selectedMatch.HomeTeamStatistics.StartingEleven;
                lTeamEvents = selectedMatch.HomeTeamEvents;
                rightPlayers = selectedMatch.AwayTeamStatistics.StartingEleven;
                rTeamEvents= selectedMatch.AwayTeamEvents;
            }
            if(selectedMatch.AwayTeam.Code == selectedCountryCode)
            {
                leftPlayers = selectedMatch.AwayTeamStatistics.StartingEleven;
                lTeamEvents= selectedMatch.AwayTeamEvents;
                rightPlayers = selectedMatch.HomeTeamStatistics.StartingEleven;
                rTeamEvents = selectedMatch.HomeTeamEvents;
            }

            playersLeft.Clear();
            playersRight.Clear();
            //foreach for pictures
            foreach (StartingEleven player in leftPlayers)
            {
                Player p = Player.LoadParameters(player);
                foreach (var pl in playersWithPictures)
                {
                    if (p == pl)
                    {
                        p.PicturePath = pl.PicturePath;
                    }
                }
                playersLeft.Add(p);
            }
            //foreach for pictures
            foreach (StartingEleven player in rightPlayers)
            {
                Player p = Player.LoadParameters(player);
                foreach (var pl in playersWithPictures)
                {
                    if (p == pl)
                    {
                        p.PicturePath = pl.PicturePath;
                    }
                }
                playersRight.Add(p);
            }
            ClearPlayersPanel();
           // int lHeight=
            foreach (var lPlayer in playersLeft)
            {
                SetLeftPlayerToPanel(lPlayer);
            }
            foreach (var rPlayer in playersRight)
            {
                SetRightPlayerToPanel(rPlayer);
            }

        }
        private async Task LoadPlayerPicturesAsync()
        {
            List<string> fileLines = await FileRepo.ReadFromFileList(DAL.Constants.ApiConstants.USER_PICTURES_PATH);
            foreach (var line in fileLines)
            {
                playersWithPictures.Add(Player.ParseFromString(line));
            }

            // settings = UserSettings.ParseFromString(fileLines);


        }

        private void ClearPlayersPanel()
        {
            spDefenderL.Children.Clear();
            spDefenderR.Children.Clear();
            spForwardL.Children.Clear();
            spForwardR.Children.Clear();
            spGoalieL.Children.Clear();
            spGoalieR.Children.Clear();
            spMidfieldL.Children.Clear();
            spMidfieldR.Children.Clear();
        }

        private void SetLeftPlayerToPanel(Player player)
        {
            PlayerUserControl playerUserControl = new PlayerUserControl(player);
            playerUserControl.MatchEvents = lTeamEvents;
            switch (player.Position)
            {
                case Position.Defender:
                    spDefenderL.Children.Add(playerUserControl);
                    break;
                case Position.Forward:
                    spForwardL.Children.Add(playerUserControl);
                    break;
                case Position.Goalie:
                    spGoalieL.Children.Add(playerUserControl);
                    break;
                case Position.Midfield:
                    spMidfieldL.Children.Add(playerUserControl);
                    break;
                default:
                    break;
            }
        }

        private void SetRightPlayerToPanel(Player player)
        {
            PlayerUserControl playerUserControl = new PlayerUserControl(player);
            playerUserControl.MatchEvents = rTeamEvents;
            switch (player.Position)
            {
                case Position.Defender:
                    spDefenderR.Children.Add(playerUserControl);
                    break;
                case Position.Forward:
                    spForwardR.Children.Add(playerUserControl);
                    break;
                case Position.Goalie:
                    spGoalieR.Children.Add(playerUserControl);
                    break;
                case Position.Midfield:
                    spMidfieldR.Children.Add(playerUserControl);
                    break;
                default:
                    break;
            }
        }

        private void lTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            if (cbTeamL.SelectedValue == null) return;
            TeamModelVersion selectedTeam = (TeamModelVersion)cbTeamL.SelectedValue;

            new TeamDetails(AllTeamMatches, selectedTeam).ShowDialog();
            //        ((TeamModelVersion) cbTeamL.SelectedValue).FifaCode.Trim();

        }

        private async void rTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            if (cbTeamR.SelectedValue == null) return;

            MyProgressBar.Visibility = Visibility.Visible;

            Team selectedTeam = (Team)cbTeamR.SelectedValue;

            List<MatchesJson> enemyTeamMatches = new List<MatchesJson>();
            try
            {
                enemyTeamMatches=await repo.GetMatchesOnline(matchesEndpoint, selectedEnemyCountryCode);
            }
            catch (Exception)
            {
                enemyTeamMatches= await repo.GetMatchesOnline(matchesLocalEndpoint, selectedEnemyCountryCode);

            }

            MyProgressBar.Visibility = Visibility.Collapsed;
            if (enemyTeamMatches.Count == 0) {
                MyProgressBar.Visibility = Visibility.Collapsed;
                MessageBox.Show("An error occuered cannot find matches right country");
                return;
            }
            new TeamDetails(enemyTeamMatches, selectedTeam).ShowDialog();


        }
    }
}
