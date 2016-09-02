using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashJobSite.Models
{
    public class JobApplication
    {
        public JobApplication()
        {
            Created = DateTime.Now;
        }

        public int Id { get; set; }

        public string CandidateName { get; set; }

        public string CandidateEmail { get; set; }

        public string CandidateInfo { get; set; }

        public virtual Job Job { get; set; }

        public DateTime Created { get; set; }
    }
}
