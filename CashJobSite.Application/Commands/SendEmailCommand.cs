
using MediatR;

namespace CashJobSite.Application.Commands
{
    public class SendEmailCommand : IRequest<Unit>
    {
        public SendEmailCommand(string toEmailAddress, string emailSubject, string emailBody)
        {
            ToEmailAddress = toEmailAddress;
            EmailSubject = emailSubject;
            EmailBody = emailBody;
        }

        public string ToEmailAddress { get; set; }

        public string EmailSubject { get; set; }

        public string EmailBody { get; set; }
    }
}
