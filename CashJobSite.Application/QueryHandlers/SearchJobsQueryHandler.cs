using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashJobSite.Application.Logging;
using CashJobSite.Application.Queries;
using CashJobSite.Data;
using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.QueryHandlers
{
    public class SearchJobsQueryHandler : IRequestHandler<SearchJobsQuery, IEnumerable<Job>>
    {
        private readonly ILogger _logger;
        private readonly ICashJobSiteDbContext _dbContext;

        public SearchJobsQueryHandler(ILogger logger, ICashJobSiteDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IEnumerable<Job> Handle(SearchJobsQuery message)
        {
            _logger.Info("Searching jobs");

            IEnumerable<Job> result;

            if (string.IsNullOrEmpty(message.Title))
            {
                result = _dbContext.Jobs.Where(job => job.Cash >= message.Cash)
                    .ToList();
            }
            else
            {
                result = _dbContext.Jobs.Where(job => job.Title.StartsWith(message.Title) && job.Cash >= message.Cash)
                    .ToList();
            }

            _logger.Info($"Found {result.Count()} jobs");

            return result;
        }
    }
}
