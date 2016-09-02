namespace CashJobSite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReporterIpAddress_To_JobReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobReports", "ReporterIpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobReports", "ReporterIpAddress");
        }
    }
}
