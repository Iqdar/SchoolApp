namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassStage = c.String(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateJoined = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stages", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Stages", new[] { "TeacherId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Stages");
        }
    }
}
