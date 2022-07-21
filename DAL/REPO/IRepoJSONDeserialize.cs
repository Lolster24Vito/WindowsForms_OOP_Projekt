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
        Task<List<TeamModelVersion>> GetTeamsOffline(string endpoint);
        Task<List<TeamModelVersion>> GetTeamsOnline(string endpoint);
        Task<List<MatchesJson>> GetMatchesOnline(string endpoint,string fifaCode);
        Task<List<MatchesJson>> GetMatchesOffline(string endpoint,string fifaCode);
        Task<MatchesJson> GetFirstMatch(string endpoint,string fifaCode);


    }
}
