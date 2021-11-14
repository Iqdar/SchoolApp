namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "Percentage", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "Percentage");
        }
    }
}
