using DAL.Models;
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
using System.Windows.Shapes;

namespace WpfApp_Projekt
{
    /// <summary>
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        public List<MatchesJson> TeamMatches { get; set; }
        public Team Team { get; set; }
        public TeamModelVersion TeamModel { get; set; }

        private bool isUsingModelTeam = false;
        private string teamCode = "";
        public TeamDetails(List<MatchesJson> teamMatches, Team team)
        {
            InitializeComponent();
            TeamMatches = teamMatches;
            Team = team;
            teamCode=team.Code;
            isUsingModelTeam = false;
            LoadInfo();
        }
        public TeamDetails(List<MatchesJson> teamMatches, TeamModelVersion team)
        {
            InitializeComponent();
            TeamMatches = teamMatches;
            TeamModel = team;
            teamCode = TeamModel.FifaCode;
            isUsingModelTeam = true;
            LoadInfo();
        }

        private void LoadInfo()
        {
            if (TeamMatches == null) return;
            if (Team != null)
            {
                lblName.Text = Team.Country;
                lblFifaCode.Text = Team.Code;
            }
            if (TeamModel != null)
            {
                lblName.Text = TeamModel.Country;
                lblFifaCode.Text = TeamModel.FifaCode;
            }

            lblNumberOfMatches.Text=TeamMatches.Count.ToString();
            long numberOfWins = 0;
            long numberOfLoses = 0;
            long numberOfDraws = 0;
            long numberOfScoredGoals = 0;
            long numberOfGoalsTaken = 0;

            foreach (var match in TeamMatches)
            {
                bool isAwayteam = false;
                if (isUsingModelTeam)
                {
                    if (match.AwayTeam.Code == TeamModel.FifaCode)
                    {
                        isAwayteam = true;
                    }
                    if (match.HomeTeam.Code == TeamModel.FifaCode)
                    {
                        isAwayteam = false;

                    }
                }
                else
                {
                    if (match.AwayTeam.Code == Team.Code)
                    {
                        isAwayteam = true;
                    }
                    if (match.HomeTeam.Code == Team.Code)
                    {
                        isAwayteam = false;

                    }
                }
                //WINS LOSSES DRAWS
                if (match.WinnerCode == teamCode) numberOfWins++;
                else
                {
                    if (match.WinnerCode == "Draw") numberOfDraws++;
                    else numberOfLoses++;
                }
                //GOALS
                if (isAwayteam)
                {

                    numberOfScoredGoals += match.AwayTeam.Goals;
                    numberOfGoalsTaken += match.HomeTeam.Goals;

                    /*
                    foreach (var teamEvent in match.AwayTeamEvents)
                    {
                        if(teamEvent.TypeOfEvent== "goal")
                        {
                            numberOfScoredGoals++;
                        }
                    }
                    foreach (var teamEvent in match.HomeTeamEvents)
                    {
                        if (teamEvent.TypeOfEvent == "goal")
                        {
                            numberOfGoalsTaken++;
                        }
                    }*/
                }
                else
                {
                    numberOfScoredGoals += match.HomeTeam.Goals;
                    numberOfGoalsTaken += match.AwayTeam.Goals;
                    /* foreach (var teamEvent in match.HomeTeamEvents)
                     {
                         if (teamEvent.TypeOfEvent == "goal")
                         {
                             numberOfScoredGoals++;
                         }
                     }
                     foreach (var teamEvent in match.AwayTeamEvents)
                     {
                         if (teamEvent.TypeOfEvent == "goal")
                         {
                             numberOfGoalsTaken++;
                         }
                     }*/
                }
            }
            lblNumberOfWins.Text = numberOfWins.ToString();
            lblNumberOfLooses.Text = numberOfLoses.ToString();
            lblNumberOfDraws.Text=numberOfDraws.ToString();
            lblScoredGoals.Text= numberOfScoredGoals.ToString();
            lblTakenGoals.Text=numberOfGoalsTaken.ToString();
            lblDifGoals.Text=(numberOfScoredGoals-numberOfGoalsTaken).ToString();

        }
    }
}
