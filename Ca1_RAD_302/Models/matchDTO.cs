using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ca1_RAD_302.Models
{
    public class MatchDTO
    {
        public int Id { get; set; }

        public string MatchTitle { get; set; }

        public String CompetitionName { get; set; }

    }

    public class MatchDetailsDTO
    {

        public int Id { get; set; }

        public String MatchTitle { get; set; }

        public DateTime KickOff { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string Draw { get; set; }

        public double HomePrice { get; set; }

        public double AwayPrice { get; set; }

        public double DrawPrice { get; set; }

        public String CompetitionName { get; set; }
    }


}