using System;
using CashJobSite.Application.Logging;

namespace CashJobSite.Application
{
    public class EmailService : IEmailService
    {
        private readonly ILogger _logger;

        public EmailService(ILogger logger)
        {
            _logger = logger;
        }

        public void SendEmail(string toEmailAddress, string emailSubject, string emailBody)
        {
            _logger.Info("Would be sending the following email \n" +
                         "  To: " + toEmailAddress + " \n" +
                         "  Subject: " + emailSubject + " \n" +
                         "  Body: " + emailBody);
        }
    }
}