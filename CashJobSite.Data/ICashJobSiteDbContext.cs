using System.Data.Entity;
using CashJobSite.Models;

namespace CashJobSite.Data
{
    public interface ICashJobSiteDbContext
    {
        DbSet<Job> Jobs { get; set; }

        DbSet<JobReport> JobReports { get; set; }

        DbSet<JobApplication> JobApplications { get; set; }

        int SaveChanges();
    }
}