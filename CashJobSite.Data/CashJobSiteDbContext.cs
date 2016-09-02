using System.Data.Entity;
using CashJobSite.Data.Migrations;
using CashJobSite.Models;

namespace CashJobSite.Data
{
    public class CashJobSiteDbContext : DbContext, ICashJobSiteDbContext
    {
        static  CashJobSiteDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CashJobSiteDbContext, Configuration>());
        }

        public CashJobSiteDbContext()
            : base("CashJobSiteConnectionString")
        { }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobReport> JobReports { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
