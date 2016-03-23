namespace Ca1_RAD_302.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fixtures", "Name", c => c.String());
            AddColumn("dbo.Matches", "MatchTitle", c => c.String());
            DropColumn("dbo.Fixtures", "Competition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fixtures", "Competition", c => c.String());
            DropColumn("dbo.Matches", "MatchTitle");
            DropColumn("dbo.Fixtures", "Name");
        }
    }
}
