using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DAL.Models
{
    public class UserSettings
    {
        public string LanguageCode { get; set; }
        public ChampionshipType? ChampionshipGroup { get; set; }

        public bool IsFullscreen { get; set; }
        public Point Resolution { get; set; }
        public override string ToString()
        {
            return LanguageCode+ System.Environment.NewLine + (int)ChampionshipGroup
                + System.Environment.NewLine+IsFullscreen+Environment.NewLine+Resolution.X
                +Environment.NewLine+Resolution.Y;
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
                ChampionshipGroup = (ChampionshipType)int.Parse(lines[1]),
                IsFullscreen=bool.Parse(lines[2]),
                Resolution=new Point(int.Parse(lines[3]),int.Parse(lines[4]))

            };
        }
    }
    public enum ChampionshipType
    {
        Female,Male
    }
}
