namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        StageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stages", t => t.StageId, cascadeDelete: true)
                .Index(t => t.StageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StageId", "dbo.Stages");
            DropIndex("dbo.Students", new[] { "StageId" });
            DropTable("dbo.Students");
        }
    }
}
