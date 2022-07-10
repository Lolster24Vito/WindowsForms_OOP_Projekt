using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsForms_OOP_Projekt.Models
{
    public class UserSettings
    {
        public string LanguageCode { get; set; }
        public ChampionshipType? ChampionshipGroup { get; set; }

        public bool IsFullscreen { get; set; }
        public Point Resolution { get; set; }
        public override string ToString()
        {
            return LanguageCode+ System.Environment.NewLine + (int)ChampionshipGroup;
        }
        public static UserSettings ParseFromString(string line)
        {
            if (line == null||line=="")
            {
                return new UserSettings { LanguageCode=null,ChampionshipGroup=null};
            }
            string[] lines = line.Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);


            return new UserSettings
            {
                LanguageCode = lines[0],
                ChampionshipGroup = (ChampionshipType)int.Parse(lines[1])
            };
        }
    }
    public enum ChampionshipType
    {
        Female,Male
    }
}
