using System.Collections.Generic;
using System.Linq;
using CashJobSite.Application.Logging;
using CashJobSite.Application.Queries;
using CashJobSite.Data;
using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.QueryHandlers
{
    public class FindAllJobsQueryHandler : IRequestHandler<FindAllJobsQuery, IEnumerable<Job>>
    {
        private readonly ILogger _logger;
        private readonly ICashJobSiteDbContext _dbContext;

        public FindAllJobsQueryHandler(ILogger logger, ICashJobSiteDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IEnumerable<Job> Handle(FindAllJobsQuery message)
        {
            _logger.Info("Finding all jobs");

            var result = _dbContext.Jobs
                .OrderByDescending(x => x.Created)
                .ToList();

            _logger.Info($"Found {result.Count()} jobs");

            return result;
        }
    }
}
