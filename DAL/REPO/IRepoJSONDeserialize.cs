using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepoJSONDeserialize
    {
        Task<List<TeamModelVersion>> GetTeams(string endpoint);
        Task<List<MatchesJson>> GetMatches(string endpoint,string fifaCode);
        Task<MatchesJson> GetFirstMatch(string endpoint,string fifaCode);


    }
}
