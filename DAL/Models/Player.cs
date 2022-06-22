using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Player : StartingEleven
    {
        private const string PARSE_SEPERATOR = "|";

        public string PicturePath { get; set; }

        public int NumberOfGoals { get; set; }
        public int NumberOfYellowCards { get; set; }
        public int NumberOfRedCards { get; set; }


        public string CountryName { get; set; }

        /* [JsonProperty("name")]
         public string Name { get; set; }

         [JsonProperty("captain")]
         public bool Captain { get; set; }

         [JsonProperty("shirt_number")]
         public long ShirtNumber { get; set; }

         [JsonProperty("position")]
         public Position Position { get; set; }*/

        public static Player LoadParameters(StartingEleven startingEleven)
        {
            return new Player()
            {
                Name = startingEleven.Name,
                Captain = startingEleven.Captain,
                ShirtNumber = startingEleven.ShirtNumber,
                Position = startingEleven.Position
            };
        }
        public static Player LoadParameters(StartingEleven startingEleven, string TeamName)
        {
            return new Player()
            {
                Name = startingEleven.Name,
                Captain = startingEleven.Captain,
                ShirtNumber = startingEleven.ShirtNumber,
                Position = startingEleven.Position,
                CountryName = TeamName

            };
        }


        public static bool operator ==(Player pl1, Player pl2)
        {
            if (pl1 is null)
            {
                if (pl2 is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            if (pl2 is null)
            {
                if (pl1 is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            return pl1.Name == pl2.Name
            && pl1.ShirtNumber == pl2.ShirtNumber;
        }

        public static bool operator !=(Player pl1, Player pl2) => !(pl1 == pl2);
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Player p = (Player)obj;
                return (Name == p.Name) && (ShirtNumber == p.ShirtNumber);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(); //string will be appended later
            sb.Append(Name);
            sb.Append(PARSE_SEPERATOR);
            sb.Append(Captain);
            sb.Append(PARSE_SEPERATOR);
            sb.Append(ShirtNumber);
            sb.Append(PARSE_SEPERATOR);
            sb.Append((int)Position);
            sb.Append(PARSE_SEPERATOR);
            sb.Append(PicturePath);
            sb.Append(PARSE_SEPERATOR);
            sb.Append(CountryName);

            return sb.ToString();


            //return LanguageCode + System.Environment.NewLine + (int)ChampionshipGroup;
        }
        public static Player ParseFromString(string line)
        {
            if (line == null || line == "")
            {
                //Ajoj;
            }
            string[] lines = line.Split(new[] { PARSE_SEPERATOR },
                StringSplitOptions.None);
            Player player;
            try
            {
                player = new Player
                {
                    Name = lines[0],
                    Captain = Boolean.Parse(lines[1]),
                    ShirtNumber = long.Parse(lines[2]),
                    Position = (Position)int.Parse(lines[3]),
                    PicturePath = lines[4],
                    CountryName = lines[5]


                };
            }
            catch (Exception)
            {

                throw;
            }



            return player;
        }

       


    }


    
        public enum Position { Defender, Forward, Goalie, Midfield };
}
