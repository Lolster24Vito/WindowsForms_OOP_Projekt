using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models;
using DAL;
using WindowsForms_OOP_Projekt.Models;
using WindowsForms_OOP_Projekt.Forms;
using DAL.REPO;
using System.Diagnostics;

namespace WindowsForms_OOP_Projekt
{
    public partial class MainForm : Form
    {
        IRepoJSONDeserialize repo = RepositoryFactory.GetRepository();
        Dictionary<string,Team> teams = new Dictionary<string,Team>();
        private string selectedCountryCode;
        private int selectedCbIndex=-1;
        private const string USER_SETTINGS_PATH = DAL.Constants.ApiConstants.USER_SETTINGS_PATH;
        private const string USER_FAVORITE_MALE_PLAYERS = DAL.Constants.ApiConstants.USER_FAVORITE_MALE_PLAYERS;
        private const string USER_FAVORITE_FEMALE_PLAYERS = DAL.Constants.ApiConstants.USER_FAVORITE_FEMALE_PLAYERS;

        private UserSettings settings;        
        private List<Player> players = new List<Player>();
        private List<Player> favPlayers = new List<Player>();



        private string matchesEndpoint="";

        private string favEndPoint = "";
        
        string endpoint = "";


        public MainForm()
        {
            InitializeComponent();
            this.ContextMenuStrip = contextMenuStrip;

        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
           
        }
        private void Init()
        {




            CheckAndApplySettingsAsync();



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

            try
            {

                FillComboBox(endpoint);
                LoadFavoritePlayersAsync();

                //  FillLabelTest();
            }
            catch (Exception)
            {

                throw;
            }
            // FillFlowLayoutPanel();
        }

        private async Task LoadFavoritePlayersAsync()
        {
            favPlayers.Clear();
            flpFavoritePlayers.Controls.Clear();
            List<string> linesList = await FileRepo.ReadFromFileList(favEndPoint);
            foreach (var line in linesList)
            {
                Player pl = Player.ParseFromString(line);
                favPlayers.Add(pl);
                AddFavoritePlayerToPanel(pl);
            }

        }

        private async void CheckAndApplySettingsAsync()
        {
            
                string fileLines = await FileRepo.ReadFromFile(USER_SETTINGS_PATH);
                settings =  UserSettings.ParseFromString(fileLines);

           

            if (settings==null ||settings.LanguageCode == null || settings.ChampionshipGroup == null)
            {
                OpenSettingsForm();
            }
            else
            {
                if (settings.ChampionshipGroup == ChampionshipType.Male)
                {
                    matchesEndpoint = DAL.Constants.ApiConstants.MALE_MATCHES_ENDPOINT;
                }
                if (settings.ChampionshipGroup == ChampionshipType.Female)
                {
                    matchesEndpoint = DAL.Constants.ApiConstants.FEMALE_MATCHES_ENDPOINT;
                }
            }
        }

        private void OpenSettingsForm()
        {
            var newForm = new LanguageGenderForm();
            newForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

      /*  private async void FillLabelTest()
        {
            List<MatchesJson> players = await repo.GetMatches(DAL.Constants.ApiConstants.FEMALE_MATCHES_ENDPOINT,"ARG");
            foreach (var player in players)
            {
                player.HomeTeamStatistics.StartingEleven.ForEach(x => label1.Text += x.Name);
            }
        }*/
        private async void LoadPlayers()
        {
            //  players = await repo.GetMatches(DAL.Constants.ApiConstants.FEMALE_MATCHES_ENDPOINT, "ARG");
            List<MatchesJson> firstMatchJson = await repo.GetMatches(matchesEndpoint, selectedCountryCode);
            
            if (firstMatchJson == null||firstMatchJson[0]==null)
            {
                return;
            }
                List<StartingEleven> startingEleven = new List<StartingEleven>();
            string teamName="";

            if (firstMatchJson[0].AwayTeam.Code == selectedCountryCode)
            {
                startingEleven = firstMatchJson[0].AwayTeamStatistics.StartingEleven;
                teamName = firstMatchJson[0].AwayTeamCountry;

            }
            if(firstMatchJson[0].HomeTeam.Code == selectedCountryCode)
            {
                startingEleven = firstMatchJson[0].HomeTeamStatistics.StartingEleven;
                teamName = firstMatchJson[0].HomeTeamCountry;

            }
            players.Clear();

            
            foreach (var player in startingEleven)
            {
                players.Add(Player.LoadParameters(player, teamName));

            }


            LoadPlayersToPanel();
            //if hometeam is selectedCountryCode get players
            //if awayteam is selected countrycode get players
            //todo starting eleven add as a local private variable
            //VITO STAO SI OVDJE TODO:
           // List<StartingEleven> startingEleven = firstMatchJson[0].HomeTeamStatistics.StartingEleven;

               // player.HomeTeamStatistics.StartingEleven.ForEach(x => label1.Text += x.Name);
            
        }
        private void LoadPlayersToPanel()
        {


            

            foreach (var player in players)
            {
                FootballPlayerUserControl playerUserController = new FootballPlayerUserControl();
                playerUserController.FootballPlayer = player;
                flowLayoutPanel1.Controls.Add(playerUserController);

            }
            bool bullshit=false;
            
        }

        private void FillFlowLayoutPanel()
        {
            if (selectedCountryCode == null || selectedCountryCode.Length == 0) {
                return;
            }
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < 15; i++)
            {
                FootballPlayerUserControl playerUserController = new FootballPlayerUserControl();
            //    playerUserController.FootballPlayer=
                flowLayoutPanel1.Controls.Add(playerUserController);
            }
        }

        private async void   FillComboBox(string endpoint)
        {
            cbTeams.Enabled = false;
                var teams = await repo.GetTeams(endpoint);
                cbTeams.DataSource = teams;

                Dictionary<string, TeamModelVersion> teamsDictionary = new Dictionary<string, TeamModelVersion>();

                foreach (var team in teams)
                {
                    teamsDictionary.Add(team.Country, team);
                }

                //if already selected automatically select and focus on other tabs
            cbTeams.Enabled = true;
            
            cbTeams.SelectedIndex = selectedCbIndex;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Refresh();

            if (cbTeams.SelectedItem != null)
            {

             var selected= cbTeams.SelectedValue;
                selectedCountryCode = TeamModelVersion.GetFifaCodeFromString(selected.ToString());
                LoadPlayers();
                //selectedCbIndex=cbTeams.SelectedIndex;
            }

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            
            selectedCbIndex = cbTeams.SelectedIndex;
            var newForm = new LanguageGenderForm();
            newForm.SetNextDialogueCheck(false);


            // Open dialog box and retrieve dialog result when ShowDialog returns
            switch (newForm.ShowDialog())
            {
                case DialogResult.Cancel:
                    label1.Text = "Cancel";
                    break;
                    case DialogResult.OK:
                    label1.Text = "OK";
                    Init();
                    break;
                 default:
                    label1.Text = "Default";

                    break;

            }
            // dialogBoxWithResult.Close();
        }

        private void flpFavoritePlayers_DragEnter(object sender, DragEventArgs e)=> e.Effect = DragDropEffects.Copy;

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            FootballPlayerUserControl footballPlayer = (FootballPlayerUserControl)e.Data.GetData(typeof(FootballPlayerUserControl));
            var fbPlayer = footballPlayer.FootballPlayer;

            bool alreadyAdded =false;
            foreach (var player in favPlayers)
            {
                if (fbPlayer == player)
                {
                    alreadyAdded = true;
                    break;
                }
            }
            if (alreadyAdded) return;

            //TODO add code for saving
            favPlayers.Add(fbPlayer);

            SaveFavoritePlayers();




            //TODO add code for adding playerUserControl to flpFavoritePlayers
            AddFavoritePlayerToPanel(fbPlayer);

        }

        private void AddFavoritePlayerToPanel(Player fbPlayer)
        {
            var copyFootballPlayer = new FootballPlayerUserControl(fbPlayer);
            flpFavoritePlayers.Controls.Add(copyFootballPlayer);
        }

        private void SaveFavoritePlayers()
        {
            List<string> lines = new List<string>();

            if (favPlayers.Count == 0) return;

            foreach (var item in favPlayers)
            {
                lines.Add( item.ToString());
            }
            //TRY ADD
           
            try
            {


                FileRepo.SaveToFile(lines, favEndPoint);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
