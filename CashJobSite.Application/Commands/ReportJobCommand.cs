using MediatR;

namespace CashJobSite.Application.Commands
{
    public class ReportJobCommand : IRequest<Unit>
    {
        public ReportJobCommand(int id, string ipAddress)
        {
            Id = id;
            IpAddress = ipAddress;
        }

        public int Id { get; set; }


        public string IpAddress { get; set; }
    }
}
