namespace CashJobSite.Application
{
    public interface IJobService
    {
        void AddJobApplication(int jobId, string candidateName, string candidateEmail, string candidateInfo);
    }
}