using System;
using System.Linq;
using CashJobSite.Application.Commands;
using CashJobSite.Application.Logging;
using CashJobSite.Data;
using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.CommandHandlers
{
    public class AddJobApplicationCommandHandler : IRequestHandler<AddJobApplicationCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        private readonly ICashJobSiteDbContext _dbContext;

        public AddJobApplicationCommandHandler(ILogger logger, IEmailService emailService, ICashJobSiteDbContext dbContext)
        {
            _logger = logger;
            _emailService = emailService;
            _dbContext = dbContext;
        }

        public Unit Handle(AddJobApplicationCommand message)
        {
            //again, could use mediator here to call back to our GetJobById query
            var job = _dbContext.Jobs.SingleOrDefault(x => x.Id == message.JobId);

            var jobApplication = new JobApplication
            {
                CandidateName = message.CandidateName,
                CandidateEmail = message.CandidateEmail,
                CandidateInfo = message.CandidateInfo,
                Job = job
            };

            _dbContext.JobApplications.Add(jobApplication);
            _dbContext.SaveChanges();

            var emailSubject = "Job application received.";
            var emailBody = "You have a new application for your job #" + job.Id + "\n" +
                            "Name: " + message.CandidateName + "\n" +
                            "Email: " + message.CandidateEmail + "\n" +
                            "Info: " + message.CandidateInfo + "\n";

            _emailService.SendEmail(job.BossEmail, emailSubject, emailBody);
            _logger.Debug("Email Sent");

            return Unit.Value;
        }
    }
}
