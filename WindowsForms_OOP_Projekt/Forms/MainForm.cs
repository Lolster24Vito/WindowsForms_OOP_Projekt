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
using WindowsForms_OOP_Projekt.Forms;
using DAL.REPO;
using System.Diagnostics;
using System.IO;
using System.Drawing.Printing;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace WindowsForms_OOP_Projekt
{
    public partial class MainForm : Form
    {
        //VITO TODO 
        //REMEMBER PICKED MAN AND WOMAN PICK and when changing in settings change back

        IRepoJSONDeserialize repo = RepositoryFactory.GetRepository();
        Dictionary<string, Team> teams = new Dictionary<string, Team>();

        private string selectedCountryCode;
        private int selectedCbIndex = 0;
        private const string USER_SETTINGS_PATH = DAL.Constants.ApiConstants.USER_SETTINGS_PATH;
        private const string USER_FAVORITE_MALE_PLAYERS = DAL.Constants.ApiConstants.USER_FAVORITE_MALE_PLAYERS;
        private const string USER_FAVORITE_FEMALE_PLAYERS = DAL.Constants.ApiConstants.USER_FAVORITE_FEMALE_PLAYERS;
        private const string USER_PICTURES_PATH = DAL.Constants.ApiConstants.USER_PICTURES_PATH;
        private const string USER_FAVORITE_TEAM = DAL.Constants.ApiConstants.USER_FAVORITE_TEAM;


        private const string CroatianResources = @"..\..\Resources\Resources.resx";
        private const string EnglishResources = @"..\..\Resources\Resources.en.resx";

        private const int FAV_PLAYERS_MAX=3;


        private UserSettings settings;
        private List<Player> players = new List<Player>();
        private List<Player> favPlayers = new List<Player>();
        private List<Player> playersWithPictures = new List<Player>();
        private List<FootballPlayerUserControl> multipleSelectedFootballPlayers = new List<FootballPlayerUserControl>();
        List<MatchesJson> AllTeamMatches;

        private string teamEndpoint = "";
        private string teamLocalEndpoint = "";
        
        private string matchesEndpoint = "";
        private string matchesLocalEndpoint = "";

        private string favEndPoint = "";



        public MainForm()
        {
            CheckAndApplySettingsAsync();
            SetCulture(settings.LanguageCode);
            InitializeComponent();
            Init();

        }
        private void MainForm_Shown(object sender, EventArgs e)
        {

        }
        private void Init()
        {




            myProgressBar.Minimum = 0;
            myProgressBar.Maximum = 100;
            myProgressBar.Value = 50;
            myProgressBar.Visible = false;



            try
            {
                LoadPlayerPicturesAsync();
                LoadFavoritePlayersAsync();
                LoadFavoriteTeam();
                FillComboBox(teamEndpoint,teamLocalEndpoint);


                //  FillLabelTest();
            }
            catch (Exception)
            {

                throw;
            }
            // FillFlowLayoutPanel();
            DataGridInit();
        }



        private void DataGridInit()
        {


            playersDataGridView.AutoGenerateColumns = false;
            playersDataGridView.AutoSize = true;

            MatchesDataGridView.AutoGenerateColumns = false;
            MatchesDataGridView.AutoSize = true;


            //do something with cases
            if (players.Count() > 0)
            {
                LoadPlayersRanksToDataGridView();
                // dataGridView1.Refresh();
            }







        }

        private async Task LoadPlayerPicturesAsync()
        {
            List<string> fileLines = await FileRepo.ReadFromFileList(USER_PICTURES_PATH);
            foreach (var line in fileLines)
            {
                playersWithPictures.Add(Player.ParseFromString(line));
            }

            // settings = UserSettings.ParseFromString(fileLines);


        }

        private async Task LoadFavoritePlayersAsync()
        {
            favPlayers.Clear();
            flpFavoritePlayers.Controls.Clear();
            List<string> linesList = await FileRepo.ReadFromFileList(favEndPoint);
            foreach (var line in linesList)
            {
                try
                {
                    Player p = Player.ParseFromString(line);
                    p.PicturePath = "";
                    foreach (var pl in playersWithPictures)
                    {
                        if (p == pl)
                        {
                            p.PicturePath = pl.PicturePath;
                        }
                    }
                    favPlayers.Add(p);
                    AddFavoritePlayerToPanel(p);
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        private async void CheckAndApplySettingsAsync()
        {

            string fileLines = await FileRepo.ReadFromFile(USER_SETTINGS_PATH);
            settings = UserSettings.ParseFromString(fileLines);





            if (settings == null || settings.LanguageCode == null || settings.ChampionshipGroup == null)
            {
                OpenSettingsForm();
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
                teamEndpoint = DAL.Constants.ApiConstants.MALE_TEAMS_ENDPOINT;
                teamLocalEndpoint = DAL.Constants.ApiConstants.MALE_TEAMS_ENDPOINT_LOCAL;
                favEndPoint = DAL.Constants.ApiConstants.USER_FAVORITE_MALE_PLAYERS;

            }
            if (settings.ChampionshipGroup == ChampionshipType.Female)
            {
                matchesEndpoint = DAL.Constants.ApiConstants.FEMALE_MATCHES_ENDPOINT;
                matchesLocalEndpoint = DAL.Constants.ApiConstants.FEMALE_MATCHES_ENDPOINT_LOCAL;

                teamEndpoint = DAL.Constants.ApiConstants.FEMALE_TEAMS_ENDPOINT;
                teamLocalEndpoint = DAL.Constants.ApiConstants.FEMALE_TEAMS_ENDPOINT_LOCAL;

                favEndPoint = DAL.Constants.ApiConstants.USER_FAVORITE_FEMALE_PLAYERS;


            }
            //SetCulture(settings.LanguageCode);



        }
        private void SetCulture(string language)
        {
            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            // UpdateUIInitializeComponent(language);
        }


        private void OpenSettingsForm()
        {
            var newForm = new LanguageGenderForm();
            newForm.ShowDialog();
        }
        private void UpdateUIInitializeComponent()
        {
            this.Controls.Clear();
            InitializeComponent();
            Init();
        }

        internal void DeselectMultipleFootballPlayers()
        {
            foreach (var p in multipleSelectedFootballPlayers)
            {
                p.BorderStyle = BorderStyle.None;
            }
            multipleSelectedFootballPlayers.Clear();
        }
        internal void SelectedMultipleFootballPlayerUserControl(FootballPlayerUserControl footballPlayer)
        {
            multipleSelectedFootballPlayers.Add(footballPlayer);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

       
        private async void LoadPlayers()
        {
            myProgressBar.Visible = true;
            myProgressBar.Value = 45;
            try
            {
            AllTeamMatches = await repo.GetMatchesOnline(matchesEndpoint, selectedCountryCode);

            }
            catch (Exception)
            {
                AllTeamMatches = await repo.GetMatchesOffline(matchesLocalEndpoint, selectedCountryCode);
            }
            myProgressBar.Value = 70;

            if (AllTeamMatches == null || AllTeamMatches[0] == null)
            {
                myProgressBar.Visible = false;
                MessageBox.Show("Error:Couldn't load team matches");

                return;
            }
            List<StartingEleven> startingEleven = new List<StartingEleven>();
            List<TeamEvent> teamEvents = new List<TeamEvent>();
            string teamName = "";

            if (AllTeamMatches[0].AwayTeam.Code == selectedCountryCode)
            {
                startingEleven = AllTeamMatches[0].AwayTeamStatistics.StartingEleven;
                teamName = AllTeamMatches[0].AwayTeamCountry;

            }
            if (AllTeamMatches[0].HomeTeam.Code == selectedCountryCode)
            {
                startingEleven = AllTeamMatches[0].HomeTeamStatistics.StartingEleven;
                teamName = AllTeamMatches[0].HomeTeamCountry;


            }

            foreach (var match in AllTeamMatches)
            {
                if (match.AwayTeam.Code == selectedCountryCode)
                {

                    teamEvents.AddRange(match.AwayTeamEvents);


                }
                if (match.HomeTeam.Code == selectedCountryCode)
                {
                    teamEvents.AddRange(match.HomeTeamEvents);
                }
            }

            players.Clear();



            foreach (var player in startingEleven)
            {
                Player p = Player.LoadParameters(player, teamName);
                foreach (var pl in playersWithPictures)
                {
                    if (p == pl)
                    {
                        p.PicturePath = pl.PicturePath;
                    }
                }
                p = LoadRankInfo(p, teamEvents);
                players.Add(p);

            }
            myProgressBar.Value = 80;


            LoadPlayersToPanel();
            myProgressBar.Value = 90;

            LoadPlayersRanksToDataGridView();
            LoadTournamentToDataGridView();
            myProgressBar.Value = 100;

            myProgressBar.Visible = false;


           

        }

        private void LoadTournamentToDataGridView()
        {
            MatchesDataGridView.Rows.Clear();
            if (settings != null)
            {
                LocalizeTournamentGridViewColumns();
            }
            AllTeamMatches.ForEach(match => MatchesDataGridView.Rows.Add(match.Location, match.HomeTeamCountry, match.AwayTeamCountry, match.Attendance));
            MatchesDataGridView.Refresh();
        }

        private void LocalizeTournamentGridViewColumns()
        {
            if (settings.LanguageCode == "hr")
            {

                using (ResXResourceSet resxSet = new ResXResourceSet(CroatianResources))
                {
                    MatchesDataGridView.Columns[0].HeaderText = resxSet.GetString("MatchesDataGridViewLocation");
                    MatchesDataGridView.Columns[1].HeaderText = resxSet.GetString("MatchesDataGridViewHomeTeam");
                    MatchesDataGridView.Columns[2].HeaderText = resxSet.GetString("MatchesDataGridViewAwayTeam");
                    MatchesDataGridView.Columns[3].HeaderText = resxSet.GetString("MatchesDataGridViewVisitors");

                }
            }
            if (settings.LanguageCode == "en")
            {
                using (ResXResourceSet resxSet = new ResXResourceSet(EnglishResources))
                {
                    MatchesDataGridView.Columns[0].HeaderText = resxSet.GetString("MatchesDataGridViewLocation");
                    MatchesDataGridView.Columns[1].HeaderText = resxSet.GetString("MatchesDataGridViewHomeTeam");
                    MatchesDataGridView.Columns[2].HeaderText = resxSet.GetString("MatchesDataGridViewAwayTeam");
                    MatchesDataGridView.Columns[3].HeaderText = resxSet.GetString("MatchesDataGridViewVisitors");

                }
            }
        }

        private void LoadPlayersRanksToDataGridView()
        {
            //dataGridView1.DataSource = players;
            playersDataGridView.Rows.Clear();
            if (settings != null)
            {
                LocalizePlayerRankGridViewColumns();
            }

            //playersDataGridView.Columns[1].HeaderText = Properties.Resources

            foreach (var p in players)
            {
                Image image;
                if (p.PicturePath != null && p.PicturePath.Trim().Length > 0 && File.Exists(p.PicturePath))
                {
                    image = Image.FromFile(p.PicturePath);
                }
                else
                {
                    image = ImagesResources.profile_icon;
                }

                playersDataGridView.Rows.Add(image,
                    p.Name, p.NumberOfGoals, p.NumberOfYellowCards, p.NumberOfRedCards);
            }
            playersDataGridView.Refresh();
        }

        private void LocalizePlayerRankGridViewColumns()
        {
            if (settings.LanguageCode == "hr")
            {

                using (ResXResourceSet resxSet = new ResXResourceSet(CroatianResources))
                {
                    playersDataGridView.Columns[0].HeaderText = resxSet.GetString("PlayerDataGridViewImage");
                    playersDataGridView.Columns[1].HeaderText = resxSet.GetString("PlayerDataGridViewName");
                    playersDataGridView.Columns[2].HeaderText = resxSet.GetString("PlayerDataGridViewNumGoals");
                    playersDataGridView.Columns[3].HeaderText = resxSet.GetString("PlayerDataGridViewNumYellow");
                    playersDataGridView.Columns[4].HeaderText = resxSet.GetString("PlayerDataGridViewNumRed");

                }
            }
            if (settings.LanguageCode == "en")
            {
                using (ResXResourceSet resxSet = new ResXResourceSet(EnglishResources))
                {
                    playersDataGridView.Columns[0].HeaderText = resxSet.GetString("PlayerDataGridViewImage");
                    playersDataGridView.Columns[1].HeaderText = resxSet.GetString("PlayerDataGridViewName");
                    playersDataGridView.Columns[2].HeaderText = resxSet.GetString("PlayerDataGridViewNumGoals");
                    playersDataGridView.Columns[3].HeaderText = resxSet.GetString("PlayerDataGridViewNumYellow");
                    playersDataGridView.Columns[4].HeaderText = resxSet.GetString("PlayerDataGridViewNumRed");

                }
            }
        }

        private Player LoadRankInfo(Player p, List<TeamEvent> teamEvents)
        {
            Player player = p;
            int yellowCardCounter = 0;
            int recCardCounter = 0;
            int goalCounter = 0;
            foreach (var eventType in teamEvents)
            {
                if (p.Name == eventType.Player)
                {
                    switch (eventType.TypeOfEvent)
                    {
                        case "yellow-card":
                            yellowCardCounter++;
                            break;
                        case "red-card":
                            recCardCounter++;
                            break;
                        case "goal":
                            goalCounter++;
                            break;
                        default:
                            break;
                    }
                }
            }
            player.NumberOfYellowCards = yellowCardCounter;
            player.NumberOfRedCards = recCardCounter;
            player.NumberOfGoals = goalCounter;
            return player;
        }

        internal void SavePictureOfPlayer(Player footballPlayer)
        {
            if (multipleSelectedFootballPlayers.Count > 0)
            {
                foreach (var playerUC in multipleSelectedFootballPlayers)
                {
                    var p = playerUC.FootballPlayer;
                    playerUC.ChangePicture(footballPlayer.PicturePath);
                    SavePictureToFileAndPanel(p);

                }
            }
            else
            {
                SavePictureToFileAndPanel(footballPlayer);
            }

        }

        private void SavePictureToFileAndPanel(Player footballPlayer)
        {
            if (playersWithPictures.Contains(footballPlayer))
            {
                List<string> lines = new List<string>();
                playersWithPictures.Remove(footballPlayer);
                playersWithPictures.Add(footballPlayer);
                foreach (var p in playersWithPictures)
                {
                    lines.Add(p.ToString());
                }

                FileRepo.SaveToFile(lines, USER_PICTURES_PATH);

            }
            else
            {
                playersWithPictures.Add(footballPlayer);
                FileRepo.SaveToFileAtEnd(footballPlayer.ToString(), USER_PICTURES_PATH);

            }
            ReloadPlayerPictures(footballPlayer);
        }
        private void ReloadPlayerPictures(Player footballPlayer)
        {
            foreach (FootballPlayerUserControl item in flpFavoritePlayers.Controls)
            {
                if (item.FootballPlayer == footballPlayer)
                {
                    item.FootballPlayer.PicturePath = footballPlayer.PicturePath;
                    item.InitLoadImage();
                }
            }
            foreach (FootballPlayerUserControl item in flpAllTeamPlayers.Controls)
            {
                if (item.FootballPlayer == footballPlayer)
                {
                    item.FootballPlayer.PicturePath = footballPlayer.PicturePath;
                    item.InitLoadImage();
                }
            }
            LoadPlayersRanksToDataGridView();




        }
        private void LoadPlayersToPanel()
        {




            foreach (var player in players)
            {
                FootballPlayerUserControl playerUserController = new FootballPlayerUserControl();
                playerUserController.FootballPlayer = player;
                if (CheckIfFavoritePlayer(player))
                {
                    playerUserController.Favorite = true;
                }

                flpAllTeamPlayers.Controls.Add(playerUserController);

            }

        }

        internal void RemoveImagesFrom(Player footballPlayer)
        {
            List<string> lines = new List<string>();
            playersWithPictures.Remove(footballPlayer);
            foreach (var p in playersWithPictures)
            {
                lines.Add(p.ToString());
            }

            FileRepo.SaveToFile(lines, USER_PICTURES_PATH);
        }



        private bool CheckIfFavoritePlayer(Player player)
        {
            foreach (var pl in favPlayers)
            {
                if (pl == player)
                {
                    return true;
                }
            }
            return false;
        }

        private void FillFlowLayoutPanel()
        {
            if (selectedCountryCode == null || selectedCountryCode.Length == 0)
            {
                return;
            }
            flpAllTeamPlayers.Controls.Clear();

            for (int i = 0; i < 15; i++)
            {
                FootballPlayerUserControl playerUserController = new FootballPlayerUserControl();
                //    playerUserController.FootballPlayer=
                flpAllTeamPlayers.Controls.Add(playerUserController);
            }
        }

        private async void FillComboBox(string endpoint,string localEndpoint)
        {
            cbTeams.Enabled = false;
            List<TeamModelVersion> teams = new List<TeamModelVersion>();
            try
            {
                teams = await repo.GetTeamsOnline(endpoint);
            }
            catch (Exception)
            {

                teams = await repo.GetTeamsOffline(localEndpoint);
            }
            if (teams.Count == 0)
            {
                MessageBox.Show("Error:Couldn't load teams");
                return;
            }
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
            cbTeams.DataSource = teams;
            cbTeams.SelectedIndex = selectedIndexFromFile;


            //if already selected automatically select and focus on other tabs
            cbTeams.Enabled = true;



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpAllTeamPlayers.Controls.Clear();
            flpAllTeamPlayers.Refresh();

            MatchesDataGridView.Rows.Clear();
            MatchesDataGridView.Refresh();

            playersDataGridView.Rows.Clear();
            playersDataGridView.Refresh();



                var selected = cbTeams.SelectedValue;
                selectedCountryCode = TeamModelVersion.GetFifaCodeFromString(selected.ToString());
                try
                {

                    SaveFavoriteTeam(selectedCountryCode);
                }
                catch (Exception)
                {

                    throw;
                }
                LoadPlayers();
                //selectedCbIndex=cbTeams.SelectedIndex;
            

        }

        private void SaveFavoriteTeam(string selectedCountryCode)
        {
            FileRepo.SaveToFile(selectedCountryCode, USER_FAVORITE_TEAM);
        }
        private async void LoadFavoriteTeam()
        {

            try
            {
                selectedCountryCode = await FileRepo.ReadFromFile(USER_FAVORITE_TEAM);
            }
            catch (Exception)
            {
                throw;
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
                    break;
                case DialogResult.OK:
                    Init();
                    break;
                default:

                    break;

            }
            var oldSettings = settings;
            CheckAndApplySettingsAsync();
            if (oldSettings.LanguageCode != settings.LanguageCode)
            {
            LocalizeTournamentGridViewColumns();
            LocalizePlayerRankGridViewColumns();
            //UpdateUIInitializeComponent(); I WISH

            }
            if (settings.ChampionshipGroup != oldSettings.ChampionshipGroup)
            {
                //RELOAD stuff
            }
            //REMOVE THIS TO NOT RUN EVERY TIME
            UpdateUIInitializeComponent();
            //IF(LanguageChanged)
            // dialogBoxWithResult.Close();
        }

        private void flpFavoritePlayers_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Copy;

        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (multipleSelectedFootballPlayers.Count == 0)
                FavoriteFootballPlayer((FootballPlayerUserControl)e.Data.GetData(typeof(FootballPlayerUserControl)));
            else
            {
                try
                {
                    foreach (var playerUserControl in multipleSelectedFootballPlayers)
                    {
                        FavoriteFootballPlayer(playerUserControl);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            DeselectMultipleFootballPlayers();
        }
        public void SaveFootballPlayerFilePanel(FootballPlayerUserControl footballPlayer)
        {
            if (favPlayers.Count < FAV_PLAYERS_MAX)
            {

            var fbPlayer = footballPlayer.FootballPlayer;
            footballPlayer.Favorite = true;
            bool alreadyAdded = false;
            foreach (var player in favPlayers)
            {
                if (fbPlayer == player)
                {
                    alreadyAdded = true;
                    break;
                }
            }
            if (alreadyAdded) return;

            favPlayers.Add(fbPlayer);

            SaveFavoritePlayers();

            AddFavoritePlayerToPanel(fbPlayer);
            }
        }

        public void FavoriteFootballPlayer(FootballPlayerUserControl footballPlayer)
        {
            if (multipleSelectedFootballPlayers.Count == 0)
            {
                SaveFootballPlayerFilePanel(footballPlayer);
            }
            else
            {
                foreach (var playerUserControl in multipleSelectedFootballPlayers)
                {
                    SaveFootballPlayerFilePanel(playerUserControl);
                }
            }
        }
        public void UnfavoriteFootballPlayer(FootballPlayerUserControl footballPlayerUserControl)
        {
            if (multipleSelectedFootballPlayers.Count == 0)
            {
                UnfavoriteFootballPlayerSaveToFileAndPanel(footballPlayerUserControl);

            }
            else
            {
                foreach (var p in multipleSelectedFootballPlayers)
                {
                    UnfavoriteFootballPlayerSaveToFileAndPanel(p);

                }
            }

        }

        private void UnfavoriteFootballPlayerSaveToFileAndPanel(FootballPlayerUserControl footballPlayerUserControl)
        {
            favPlayers.Remove(footballPlayerUserControl.FootballPlayer);

            foreach (FootballPlayerUserControl control in flpAllTeamPlayers.Controls)
            {
                if (footballPlayerUserControl.FootballPlayer == control.FootballPlayer)
                {
                    control.Favorite = false;
                }
            }
            foreach (FootballPlayerUserControl control in flpFavoritePlayers.Controls)
            {
                if (footballPlayerUserControl.FootballPlayer == control.FootballPlayer)
                {
                    control.RemoveFavoriteStar();
                }
            }
            RemoveFavoritePlayerToPanel(footballPlayerUserControl);
            SaveFavoritePlayers();
        }

        private void RemoveFavoritePlayerToPanel(FootballPlayerUserControl fbPlayer)
        {
            flpFavoritePlayers.Controls.Remove(fbPlayer);
            foreach (FootballPlayerUserControl control in flpFavoritePlayers.Controls)
            {
                if (fbPlayer.FootballPlayer == control.FootballPlayer)
                {
                    flpFavoritePlayers.Controls.Remove(control);
                }
            }
        }

        private void AddFavoritePlayerToPanel(Player fbPlayer)
        {
            var copyFootballPlayer = new FootballPlayerUserControl(fbPlayer);
            copyFootballPlayer.Favorite = true;
            flpFavoritePlayers.Controls.Add(copyFootballPlayer);
        }

        private void SaveFavoritePlayers()
        {
            List<string> lines = new List<string>();

            foreach (var item in favPlayers)
            {
                lines.Add(item.ToString());
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





        private void flpFavoritePlayers_Click(object sender, EventArgs e)
        {

            DeselectMultipleFootballPlayers();

        }


        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var x = e.MarginBounds.Left;
            var y = e.MarginBounds.Top;

            if (printPlayers)
            {


                var bmp = new Bitmap(playersDataGridView.Size.Width, playersDataGridView.Size.Height);

                // svaka kontrola ima definiranu metodu DrawToBitmap
                playersDataGridView.DrawToBitmap(bmp, new Rectangle
                {
                    X = 0,
                    Y = 0,
                    Width = playersDataGridView.Width,
                    Height = playersDataGridView.Height
                });

                e.Graphics.DrawImage(bmp, x, y);
            }
            else if (printMatches)
            {


                var bmp = new Bitmap(this.Size.Width, this.Size.Height);

                // svaka kontrola ima definiranu metodu DrawToBitmap
                MatchesDataGridView.DrawToBitmap(bmp, new Rectangle
                {
                    X = 0,
                    Y = 0,
                    Width = MatchesDataGridView.Width,
                    Height = MatchesDataGridView.Height
                });

                e.Graphics.DrawImage(bmp, x, y);
            }
        }
        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter)
            {
                MessageBox.Show("Gotovo je printanje.");
            }
        }


        private bool printPlayers = false;
        private void btnPrintPlayers_Click(object sender, EventArgs e)
        {
            printPlayers = true;
            printMatches = false;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void btnPreviewPlayers_Click(object sender, EventArgs e)
        {
            printPlayers = true;
            printMatches = false;
            printPreviewDialog.ShowDialog();

        }
        private bool printMatches = false;

        private void btnPrintMatches_Click(object sender, EventArgs e)
        {
            printMatches = true;
            printPlayers = false;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void btnPreviewMatches_Click(object sender, EventArgs e)
        {
            printMatches = true;
            printPlayers = false;
            printPreviewDialog.ShowDialog();

        }
    }
}
