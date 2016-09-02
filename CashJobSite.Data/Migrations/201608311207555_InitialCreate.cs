namespace CashJobSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateName = c.String(),
                        CandidateEmail = c.String(),
                        CandidateInfo = c.String(),
                        Created = c.DateTime(nullable: false),
                        Job_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .Index(t => t.Job_Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        BossEmail = c.String(),
                        Cash = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Job_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .Index(t => t.Job_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobReports", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.JobApplications", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.JobReports", new[] { "Job_Id" });
            DropIndex("dbo.JobApplications", new[] { "Job_Id" });
            DropTable("dbo.JobReports");
            DropTable("dbo.Jobs");
            DropTable("dbo.JobApplications");
        }
    }
}
