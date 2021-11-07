namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTable3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoursCode = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        StageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stages", t => t.StageId, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.TeacherId)
                .Index(t => t.StageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Subjects", "StageId", "dbo.Stages");
            DropIndex("dbo.Subjects", new[] { "StageId" });
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropTable("dbo.Subjects");
        }
    }
}
