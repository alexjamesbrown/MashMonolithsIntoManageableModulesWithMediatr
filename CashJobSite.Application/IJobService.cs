using System.Collections.Generic;
using CashJobSite.Models;

namespace CashJobSite.Application
{
    public interface IJobService
    {
        IEnumerable<Job> SearchJobs(string title, int cash);

        void ReportJob(int id, string ipAddress);

        void AddJobApplication(int jobId, string candidateName, string candidateEmail, string candidateInfo);
    }
}