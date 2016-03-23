namespace Ca1_RAD_302.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fixtures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Competition = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KickOff = c.DateTime(nullable: false),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        Draw = c.String(),
                        HomePrice = c.Double(nullable: false),
                        AwayPrice = c.Double(nullable: false),
                        DrawPrice = c.Double(nullable: false),
                        FixtureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fixtures", t => t.FixtureId, cascadeDelete: true)
                .Index(t => t.FixtureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "FixtureId", "dbo.Fixtures");
            DropIndex("dbo.Matches", new[] { "FixtureId" });
            DropTable("dbo.Matches");
            DropTable("dbo.Fixtures");
        }
    }
}
