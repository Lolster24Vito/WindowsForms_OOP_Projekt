using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RestSharp;
using Newtonsoft.Json;
using DAL.Constants;
using System.IO;
using System.Text.Json;
using DAL.REPO;

namespace DAL
{
    public class RepositoryJSON:IRepoJSONDeserialize
    {
        public Task<List<TeamModelVersion>> GetTeamsOnline(string endpoint)
        {
            try
            {

                return Task.Run(() => {
                    var apiClient = new RestClient(endpoint);
                    var apiResult = apiClient.ExecuteAsync<List<TeamModelVersion>>(new RestRequest());

                    var teamList = JsonConvert.DeserializeObject<List<TeamModelVersion>>(apiResult.Result.Content);
                   // throw new Exception("TestAlwaysFail");
                    return teamList;

                });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Task<List<TeamModelVersion>> GetTeamsOffline(string endpoint)
        {
            try
            {

                return Task.Run(() => {
                    return JsonConvert.DeserializeObject<List<TeamModelVersion>>(FileRepo.ReadFromFile(endpoint).Result);

                });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Task<List<MatchesJson>> GetMatchesOnline(string endpoint, string fifaCode)
        {
            return Task.Run(() => {
                var apiClient = new RestClient(endpoint + "/country?fifa_code=" + fifaCode);
                var apiResult = apiClient.ExecuteAsync<List<MatchesJson>>(new RestRequest());
                try
                {
                    var teamList = JsonConvert.DeserializeObject<List<MatchesJson>>(apiResult.Result.Content);
                    return teamList;

                }
                catch (Exception ex)
                {
                    return null;
                }


            });
        }
        public Task<List<MatchesJson>> GetMatchesOffline(string endpoint, string fifaCode)
        {
            try
            {
                
                return (Task.Run(() => {
                    return JsonConvert.DeserializeObject<List<MatchesJson>>(FileRepo.ReadFromFile(endpoint).Result)
                    .ToList().Where(m => m.HomeTeam.Code == fifaCode || m.AwayTeam.Code == fifaCode).ToList();

                }));
            }
            catch (Exception)
            {

                return null;
            }



        }


        public Task<MatchesJson> GetFirstMatch(string endpoint, string fifaCode)
        {
            return Task.Run(() => {
                var apiClient = new RestClient(endpoint + "/country?fifa_code=" + fifaCode);
                var apiResult = apiClient.ExecuteAsync<MatchesJson>(new RestRequest());

                var teamList = JsonConvert.DeserializeObject<MatchesJson>(apiResult.Result.Content);

                return teamList;

            });
        }





    }
}
