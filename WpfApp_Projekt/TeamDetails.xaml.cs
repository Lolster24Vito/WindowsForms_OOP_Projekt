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
        public TeamDetails(List<MatchesJson> teamMatches,Team team)
        {
            InitializeComponent();
            TeamMatches = teamMatches;
            Team = team;
            LoadInfo();
        }

        private void LoadInfo()
        {
            if (TeamMatches == null) return;

            
        }
    }
}
