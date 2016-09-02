using System.Collections.Generic;
using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.Queries
{
    public class FindAllJobsQuery : IRequest<IEnumerable<Job>>
    {
    }
}
