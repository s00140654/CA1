using System;
using System.Collections.Generic;
using System.Linq;
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

    
}