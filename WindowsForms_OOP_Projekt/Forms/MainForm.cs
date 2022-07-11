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

namespace WindowsForms_OOP_Projekt
{
    public partial class MainForm : Form
    {
        IRepoJSONDeserialize repo = RepositoryFactory.GetRepository();
        Dictionary<string, Team> teams = new Dictionary<string, Team>();

        private string selectedCountryCode;
        private int selectedCbIndex = 0;
        private const string USER_SETTINGS_PATH = DAL.Constants.ApiConstants.USER_SETTINGS_PATH;
        private const string USER_FAVORITE_MALE_PLAYERS = DAL.Constants.ApiConstants.USER_FAVORITE_MALE_PLAYERS;
        private const string USER_FAVORITE_FEMALE_PLAYERS = DAL.Constants.ApiConstants.USER_FAVORITE_FEMALE_PLAYERS;
        private const string USER_PICTURES_PATH = DAL.Constants.ApiConstants.USER_PICTURES_PATH;
        private const string USER_FAVORITE_TEAM = DAL.Constants.ApiConstants.USER_FAVORITE_TEAM;

        private UserSettings settings;
        private List<Player> players = new List<Player>();
        private List<Player> favPlayers = new List<Player>();
        private List<Player> playersWithPictures = new List<Player>();
        private List<FootballPlayerUserControl> multipleSelectedFootballPlayers = new List<FootballPlayerUserControl>();
        List<MatchesJson> AllTeamMatches;

        private string teamEndpoint = "";
        private string matchesEndpoint = "";

        private string favEndPoint = "";


        private bool firstTimeLoadingComboBox = true;

        public MainForm()
        {
            InitializeComponent();
            Init();

        }
        private void MainForm_Shown(object sender, EventArgs e)
        {

        }
        private void Init()
        {



            CheckAndApplySettingsAsync();



           

            try
            {
                LoadPlayerPicturesAsync();
                LoadFavoritePlayersAsync();
                LoadFavoriteTeam();
                FillComboBox(teamEndpoint);


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
                teamEndpoint = DAL.Constants.ApiConstants.MALE_TEAMS_ENDPOINT;
            }
            if (settings.ChampionshipGroup == ChampionshipType.Female)
            {
                matchesEndpoint = DAL.Constants.ApiConstants.FEMALE_MATCHES_ENDPOINT;
                teamEndpoint = DAL.Constants.ApiConstants.FEMALE_TEAMS_ENDPOINT;

            }



        }



        private void OpenSettingsForm()
        {
            var newForm = new LanguageGenderForm();
            newForm.ShowDialog();
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
            AllTeamMatches = await repo.GetMatches(matchesEndpoint, selectedCountryCode);

            if (AllTeamMatches == null || AllTeamMatches[0] == null)
            {

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


            LoadPlayersToPanel();
            LoadPlayersRanksToDataGridView();
            LoadTournamentToDataGridView();
            //if hometeam is selectedCountryCode get players
            //if awayteam is selected countrycode get players
            //todo starting eleven add as a local private variable
            //VITO STAO SI OVDJE TODO:
            // List<StartingEleven> startingEleven = firstMatchJson[0].HomeTeamStatistics.StartingEleven;

            // player.HomeTeamStatistics.StartingEleven.ForEach(x => label1.Text += x.Name);

        }

        private void LoadTournamentToDataGridView()
        {
            MatchesDataGridView.Rows.Clear();
            AllTeamMatches.ForEach(match => MatchesDataGridView.Rows.Add(match.Location, match.HomeTeamCountry, match.AwayTeamCountry, match.Attendance));
            MatchesDataGridView.Refresh();
        }

        private void LoadPlayersRanksToDataGridView()
        {
            //dataGridView1.DataSource = players;
            playersDataGridView.Rows.Clear();

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

        private async void FillComboBox(string endpoint)
        {
            cbTeams.Enabled = false;
            var teams = await repo.GetTeams(endpoint);
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
            firstTimeLoadingComboBox = false;
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

            if (!firstTimeLoadingComboBox)
            {

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
