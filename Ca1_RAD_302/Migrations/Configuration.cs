namespace Ca1_RAD_302.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ca1_RAD_302.Models.Ca1_RAD_302Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        public object AsyncContext { get; private set; }
       
        protected override void Seed(Ca1_RAD_302.Models.Ca1_RAD_302Context context)
        {   
            // FixturesResponse task = GetFixtures.RunAsync();

            context.Fixtures.AddOrUpdate(x => x.Id,
                new Fixture() { Id = 1, Name = "English Premiership" },
                new Fixture() { Id = 2, Name = "LOI Premiership" }
                );
            context.Matches.AddOrUpdate(x => x.Id,
        new Match()
        {
            Id = 1,
            KickOff = DateTime.Parse("01/04/2016"),
            MatchTitle = "Arsenal v Liverpool",
            HomeTeam = "Arsenal",
            AwayTeam = "Liverpool",
            Draw = "Draw",
            HomePrice = 2.88,
            AwayPrice = 2.88,
            DrawPrice = 2.88,
            FixtureId = 1

            
        },
        new Match()
        {
            Id = 2,
            KickOff = DateTime.Parse("01/04/2016"),
            MatchTitle = "Man Utd v West Ham",
            HomeTeam = "Man Utd",
            AwayTeam = "West Ham",
            Draw = "Draw",
            HomePrice = 2.88,
            AwayPrice = 2.88,
            DrawPrice = 2.88,
            FixtureId = 1

        },
        new Match()
        {
            Id = 3,
            KickOff = DateTime.Parse("01/04/2016"),
            MatchTitle = "Sligo Rovers v Dundalk",
            HomeTeam = "Sligo Rovers",
            AwayTeam = "Dundalk",
            Draw = "Draw",
            HomePrice = 2.88,
            AwayPrice = 2.88,
            DrawPrice = 2.88,
            FixtureId = 2

        },
        new Match()
        {
            Id = 4,
            KickOff = DateTime.Parse("01/04/2016"),
            MatchTitle = "Bohs v St Pats",
            HomeTeam = "Boh's",
            AwayTeam = "St Pat's",
            Draw = "Draw",
            HomePrice = 2.88,
            AwayPrice = 2.88,
            DrawPrice = 2.88,
            FixtureId = 2

        }
        );


          
            


        }
    }
}
