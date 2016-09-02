using System;

namespace CashJobSite.Models
{
    public class JobReport
    {
        public JobReport()
        {
            Created = DateTime.Now;
        }

        public int Id { get; set; }

        public virtual Job Job { get; set; }

        public string ReporterIpAddress { get; set; }

        public DateTime Created { get; set; }
    }
}