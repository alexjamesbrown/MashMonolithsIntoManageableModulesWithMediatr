using MediatR;

namespace CashJobSite.Application.Commands
{
    public class AddJobApplicationCommand : IRequest<Unit>
    {
        public AddJobApplicationCommand(int jobId, string candidateName, string candidateEmail, string candidateInfo)
        {
            JobId = jobId;
            CandidateName = candidateName;
            CandidateEmail = candidateEmail;
            CandidateInfo = candidateInfo;
        }

        public int JobId { get; set; }

        public string CandidateName { get; set; }

        public string CandidateEmail { get; set; }

        public string CandidateInfo { get; set; }
    }
}
