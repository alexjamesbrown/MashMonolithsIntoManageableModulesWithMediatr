using System.Linq;
using CashJobSite.Application.Commands;
using CashJobSite.Application.Logging;
using CashJobSite.Data;
using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.CommandHandlers
{
    public class ReportJobCommandHandler : IRequestHandler<ReportJobCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        private readonly ICashJobSiteDbContext _dbContext;

        public ReportJobCommandHandler(ILogger logger, IEmailService emailService, ICashJobSiteDbContext dbContext)
        {
            _logger = logger;
            _emailService = emailService;
            _dbContext = dbContext;
        }

        public Unit Handle(ReportJobCommand message)
        {
            //could also use the mediator here to call back to our GetJobById query
            var job = _dbContext.Jobs.SingleOrDefault(x => x.Id == message.Id);

            var emailSubject = "Job '" + job.Title + "' has been reported.";
            var emailBody = "Somebody has reported job #" + job.Id;

            _emailService.SendEmail("admin@CashJobSiteCashJobSite.com", emailSubject, emailBody);
            _logger.Debug("Email Sent");

            var jobReport = new JobReport { Job = job, ReporterIpAddress = message.IpAddress };

            _dbContext.JobReports.Add(jobReport);
            _dbContext.SaveChanges();

            _logger.Debug("Job report saved");

            //effectively return void
            return Unit.Value;
        }
    }
}
