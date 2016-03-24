using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ca1_RAD_302.Models
{
    public class Fixture
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Match
    {
        public int Id   { get; set; }

        public string MatchTitle { get; set; }

        public DateTime KickOff { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam  { get; set; }

        public string Draw { get; set; }

        public double HomePrice { get; set; }

        public double AwayPrice { get; set; }

        public double DrawPrice { get; set; }

        public int FixtureId { get; set; }

        public Fixture Fixture { get; set; }

    }

    public class GetFixtures
    {
        public int Id { get; set; }

        public long Since { get; set; }

        public int SportId { get; set; }

        public List<int> LeagueIds { get; set; }

        public bool IsLive { get; set; }

        public static FixturesResponse fixturesResponse { get; set; }
    // public HttpClient _httpClient;

         public GetFixtures()
        {


        }

        public static async Task<FixturesResponse> RunAsync()
        {
           HttpClient _httpClient= new HttpClient() ;
 
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "GG862057", "@1sideside"))));

            var response = await _httpClient.GetAsync(string.Format("https://api.pinnaclesports.com/v1/fixtures?sportid=29")).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();

            
            fixturesResponse = JsonConvert.DeserializeObject<FixturesResponse>(json);

            return fixturesResponse;
        }
    }


    public class FixturesResponse
     {
        public int sportId { get; set; }

        public int last { get; set; }

        public List<League> league { get; set; }

    }


    public class League
    {
        public int id { get; set; }

        public List<Events> events { get; set; }

        public FixturesResponse fixturesResponse { get; set; }
    }

    public class Events
    {
       
        public int id { get; set; }

        public string starts { get; set; }

        public string home { get; set; }

        public string away { get; set; }

        public string rotNum { get; set; }

        public int liveStatus { get; set; }

        public string status { get; set; }

        public int parlayRestriction { get; set; }

        public League league { get; set; }


    }


}