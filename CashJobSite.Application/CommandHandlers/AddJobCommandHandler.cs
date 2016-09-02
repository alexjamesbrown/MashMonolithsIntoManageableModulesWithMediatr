using System;
using CashJobSite.Application.Commands;
using CashJobSite.Application.Logging;
using CashJobSite.Data;
using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.CommandHandlers
{
    public class AddJobCommandHandler : IRequestHandler<AddJobCommand, Job>
    {
        private readonly ILogger _logger;
        private readonly ICashJobSiteDbContext _dbContext;

        public AddJobCommandHandler(ILogger logger, ICashJobSiteDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Job Handle(AddJobCommand message)
        {
            try
            {
                _logger.Info("Saving job");

                _dbContext.Jobs.Add(message.Job);
                _dbContext.SaveChanges();

                _logger.Info("Job saved");

                return message.Job;
            }
            catch (Exception ex)
            {
                _logger.Error("Error saving job - " + ex.Message);
                throw;
            }
        }
    }
}
