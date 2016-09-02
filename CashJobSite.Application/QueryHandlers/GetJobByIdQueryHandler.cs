using System.Linq;
using CashJobSite.Application.Logging;
using CashJobSite.Application.Queries;
using CashJobSite.Data;
using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.QueryHandlers
{
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, Job>
    {
        private readonly ILogger _logger;
        private readonly ICashJobSiteDbContext _dbContext;

        public GetJobByIdQueryHandler(ILogger logger, ICashJobSiteDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Job Handle(GetJobByIdQuery message)
        {
            _logger.Info("Getting job with id " + message.Id);
            return _dbContext.Jobs.SingleOrDefault(x => x.Id == message.Id);
        }
    }
}
