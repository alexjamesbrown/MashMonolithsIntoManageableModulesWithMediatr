namespace CashJobSite.Application
{
    public interface IJobService
    {
        void ReportJob(int id, string ipAddress);

        void AddJobApplication(int jobId, string candidateName, string candidateEmail, string candidateInfo);
    }
}