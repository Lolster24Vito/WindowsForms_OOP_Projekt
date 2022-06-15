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


namespace DAL
{
    public class RepositoryJSON:IRepoJSONDeserialize
    {
        
       

        
        public Task<List<TeamModelVersion>> GetTeams(string endpoint)
        {
            try
            {

            return Task.Run(() => {
                var apiClient = new RestClient(endpoint);
                var apiResult = apiClient.ExecuteAsync<List<TeamModelVersion>>(new RestRequest());
                    
                var teamList= JsonConvert.DeserializeObject<List<TeamModelVersion>>(apiResult.Result.Content);

                return teamList;

            });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Task<List<MatchesJson>> GetMatches(string endpoint,string fifaCode)
        {
            return Task.Run(() => {
                var apiClient = new RestClient(endpoint + "/country?fifa_code="+fifaCode);
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

        public Task<MatchesJson> GetFirstMatch(string endpoint, string fifaCode)
        {
            return Task.Run(() => {
                var apiClient = new RestClient(endpoint + "/country?fifa_code=" + fifaCode);
                var apiResult = apiClient.ExecuteAsync<MatchesJson>(new RestRequest());

                var teamList = JsonConvert.DeserializeObject<MatchesJson>(apiResult.Result.Content);

                return teamList;

            });
        }


        /*
         * public Task<List<Team>> GetTeams()
        {
            return Task.Run(() => {
                var apiClient = new RestClient(ApiConstants.ENDPOINT);
                var apiResult = apiClient.ExecuteAsync<List<Team>>(new RestRequest());


                return JsonConvert.DeserializeObject<List<Team>>(apiResult.Result.Content);

            });
        }
        */


        /*
        private  Task<IRestResponse<TeamsData>> GetRawData()
        {
            var apiClient = new RestClient(ApiConstants.ENDPOINT);
            return apiClient.ExecuteAsync<TeamsData>(new RestRequest());
        }
        private TeamsData GetDeserializedObject(IRestResponse<TeamsData> teamsRawData)
        {
            return JsonConvert.DeserializeObject<TeamsData>(teamsRawData.Content);
        }

        private Task<Team> GetData()
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(ApiConstants.ENDPOINT);
                var apiResult = apiClient.Execute<Team>(new RestRequest());

                // Simulates long operation

                return JsonConvert.DeserializeObject<Team>(apiResult.Content);
            });
        }

        private List<Team> GetDataSync()
        {
            var apiClient = new RestClient(ApiConstants.ENDPOINT);
            var apiResult = apiClient.Execute<TeamsData>(new RestRequest());
            return JsonConvert.DeserializeObject<List<Team>>(apiResult.Content);
        }
        private Team[] GetDataFile()
        {
            string jsonString =@"C:\Users\vitom\source\repos\WindowsForms_OOP_Projekt\DAL\teams.json";
            return System.Text.Json.JsonSerializer.Deserialize<Team[]>(jsonString);
        }
        */
    }
}
