namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTable4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Term = c.String(nullable: false),
                        StudentId = c.Int(nullable: false),
                        StageId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stages", t => t.StageId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.StageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Results", "StageId", "dbo.Stages");
            DropIndex("dbo.Results", new[] { "StageId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropTable("dbo.Results");
        }
    }
}
