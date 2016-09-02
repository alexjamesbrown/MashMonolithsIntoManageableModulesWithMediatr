using CashJobSite.Application.Commands;
using CashJobSite.Application.Logging;
using MediatR;

namespace CashJobSite.Application.CommandHandlers
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Unit>
    {
        private readonly ILogger _logger;

        public SendEmailCommandHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Unit Handle(SendEmailCommand message)
        {
            _logger.Info("Would be sending the following email \n" +
                         "  To: " + message.ToEmailAddress + " \n" +
                         "  Subject: " + message.EmailSubject + " \n" +
                         "  Body: " + message.EmailBody);

            return Unit.Value;
        }
    }
}
