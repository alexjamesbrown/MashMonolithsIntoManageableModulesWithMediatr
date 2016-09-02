using System;
using System.Data.Entity.Migrations;
using System.Linq;
using CashJobSite.Models;

namespace CashJobSite.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CashJobSiteDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CashJobSiteDbContext context)
        {
            if (context.Jobs.Any())
                return;

            context.Jobs.AddOrUpdate(CreateJob(50, "Paint a wall", "Paint a wall in my house. The wall is small. Around 200ft long.", "2016-01-12"));
            context.Jobs.AddOrUpdate(CreateJob(10, "Clean my car", "Need my car cleaning.", "2016-2-14"));
        }

        private Job CreateJob(int cash, string title, string description, string yyyymmdd)
        {
            var dateParts = yyyymmdd.Split('-');
            var created = new DateTime(Convert.ToInt32(dateParts[0]), Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]));

            return new Job
            {
                Cash = cash,
                Created = created,
                Description = description,
                Title = title
            };
        }
    }
}