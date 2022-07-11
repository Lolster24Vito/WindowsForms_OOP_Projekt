using DAL;
using DAL.Models;
using DAL.REPO;
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
        private string teamsEndpoint = "";

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            CheckAndApplySettingsAsync();
            try
            {
                FillCombobox(teamsEndpoint);

            }
            catch (Exception)
            {

                throw;
            }
            /*



            if (settings.ChampionshipGroup == ChampionshipType.Male)
            {
                endpoint = DAL.Constants.ApiConstants.MALE_TEAMS_ENDPOINT;
                favEndPoint = DAL.Constants.ApiConstants.USER_FAVORITE_MALE_PLAYERS;


            }
            if (settings.ChampionshipGroup == ChampionshipType.Female)
            {
                endpoint = DAL.Constants.ApiConstants.FEMALE_TEAMS_ENDPOINT;
                favEndPoint = DAL.Constants.ApiConstants.USER_FAVORITE_FEMALE_PLAYERS;


            }
            */

        }

        private async void FillCombobox(string endpoint)
        {
            List<TeamModelVersion> teams = await repo.GetTeams(endpoint);
            /* int selectedIndexFromFile = 0;
             int counter = 0;
             foreach (var t in teams)
             {
                 if (t.FifaCode == selectedCountryCode.Trim())
                 {
                     selectedIndexFromFile = counter;
                     break;
                 }
                 counter++;
             }*/
            cbTeamL.Items.Clear();
            cbTeamL.ItemsSource = teams;


        }
        private async void CheckAndApplySettingsAsync()
        {

            string fileLines = await FileRepo.ReadFromFile(USER_SETTINGS_PATH);
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
                teamsEndpoint = DAL.Constants.ApiConstants.MALE_TEAMS_ENDPOINT;

            }
            if (settings.ChampionshipGroup == ChampionshipType.Female)
            {
                matchesEndpoint = DAL.Constants.ApiConstants.FEMALE_MATCHES_ENDPOINT;
                teamsEndpoint = DAL.Constants.ApiConstants.FEMALE_TEAMS_ENDPOINT;

            }


        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            new UserSettingsWindow().ShowDialog();
        }
    }
}
