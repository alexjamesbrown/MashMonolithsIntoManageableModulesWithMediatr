
using System;
using System.Collections.Generic;

namespace CashJobSite.Models
{
    public class Job
    {
        public Job()
        {
            Created = DateTime.Now;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string BossEmail { get; set; }

        public int Cash { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<JobReport> Reports { get; set; }

        public virtual ICollection<JobApplication> Applications { get; set; }
    }
}
