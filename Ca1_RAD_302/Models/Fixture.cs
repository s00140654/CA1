using Ca1_RAD_302.Controllers;
using Ca1_RAD_302.Migrations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [StringLength(50,MinimumLength = 2)]
        public string MatchTitle { get; set; }

        public DateTime KickOff { get; set; }
       
        [StringLength(50, MinimumLength = 2)]
        public string HomeTeam { get; set; }
        
        [StringLength(50, MinimumLength = 2)]
        public string AwayTeam  { get; set; }
        [StringLength(50, MinimumLength = 2)]
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
            Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "00ffc9d2f0bef0720d03f6f15df02d9e", "9dd0c4e5e0aa4530298846c4bce96593"))));

            var response = await _httpClient.GetAsync(string.Format("https://api.pinnaclesports.com/v1/fixtures?sportid=29&leagueids=1792")).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();

            var jobject = JsonConvert.DeserializeObject<FixturesResponse>(json);
            fixturesResponse = JsonConvert.DeserializeObject<FixturesResponse>(json);

            var t = fixturesResponse;
            Ca1_RAD_302Context db = new Ca1_RAD_302Context();
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [matches]");
            for (int i = 0; i < fixturesResponse.league[0].events.Count(); i++ )
            {

                Match match = new Match()
                {
                    Id = t.league[0].events[i].id,
                    KickOff = DateTime.Parse(t.league[0].events[0].starts),
                    MatchTitle = t.league[0].events[i].home+ " V "+ t.league[0].events[i].away,
                    HomeTeam = t.league[0].events[i].home,
                    AwayTeam = t.league[0].events[i].away,
                    Draw = "Draw",
                    HomePrice = 2.88,
                    AwayPrice = 2.88,
                    DrawPrice = 2.88,
                    FixtureId = 1

                };
               
                db.Matches.Add(match);
                
            }
            db.SaveChanges();

            //    db.Fixtures.AddOrUpdate(x => x.Id,
            //        new Fixture() { Id = 1, Name = "English Premiership" },
            //        new Fixture() { Id = 2, Name = "LOI Premiership" }
            //        );
            //    db.Matches.AddOrUpdate(x => x.Id,
            //new Match()
            //{
            //    Id = 1,
            //    KickOff = DateTime.Parse("01/04/2016"),
            //    MatchTitle = "Arsenal v Liverpool",
            //    HomeTeam = "Arsenal",
            //    AwayTeam = "Liverpool",
            //    Draw = "Draw",
            //    HomePrice = 2.88,
            //    AwayPrice = 2.88,
            //    DrawPrice = 2.88,
            //    FixtureId = 1


            //}



            //Ca1_RAD_302Context db = new Ca1_RAD_302Context();
            // db.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableName]");

            return fixturesResponse;

           

        }
    }

    public class Event
    {
        public int id { get; set; }
        public string starts { get; set; }
        public string home { get; set; }
        public string away { get; set; }
        public string rotNum { get; set; }
        public int liveStatus { get; set; }
        public string status { get; set; }
        public int parlayRestriction { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public List<Event> events { get; set; }
    }

    public class FixturesResponse
    {
        public int sportId { get; set; }
        public int last { get; set; }
        public List<League> league { get; set; }
    }


    //public class FixturesResponse
    // {
    //    public int sportId { get; set; }

    //    public int last { get; set; }

    //    public List<League> league;

    //}


    //public class League
    //{
    //    public int id { get; set; }

    //    public List<Events> events { get; set; }

    //    public FixturesResponse fixturesResponse { get; set; }
    //}

    //public class Events
    //{

    //    public int id { get; set; }

    //    public string starts { get; set; }

    //    public string home { get; set; }

    //    public string away { get; set; }

    //    public string rotNum { get; set; }

    //    public int liveStatus { get; set; }

    //    public string status { get; set; }

    //    public int parlayRestriction { get; set; }

    //    public League league { get; set; }


    //}

    //public class RootObject
    //{
    //    public FixturesResponse[] events { get; set; }
    //}


}