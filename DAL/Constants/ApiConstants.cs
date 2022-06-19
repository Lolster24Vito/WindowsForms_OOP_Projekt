using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Constants
{
    public static class ApiConstants
    {
        public const string FEMALE_TEAMS_ENDPOINT = "http://worldcup.sfg.io/teams";
        public const string MALE_TEAMS_ENDPOINT = "http://world-cup-json-2018.herokuapp.com/teams";
        public const string FEMALE_MATCHES_ENDPOINT = "http://worldcup.sfg.io/matches";
        public const string MALE_MATCHES_ENDPOINT = "http://world-cup-json-2018.herokuapp.com/matches";
        
        public const string USER_SETTINGS_PATH = "userSettings.txt";
        public const string USER_FAVORITE_MALE_PLAYERS = "userFavoriteMalePlayers.txt";
        public const string USER_FAVORITE_FEMALE_PLAYERS = "userFavoriteFemalePlayers.txt";
        public const string USER_PICTURES_PATH = "userPlayerPictures.txt";




    }
}
