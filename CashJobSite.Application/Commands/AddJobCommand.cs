using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.Commands
{
    public class AddJobCommand : IRequest<Job>
    {
        public Job Job { get; set; }

        public AddJobCommand(Job job)
        {
            Job = job;
        }
    }
}
