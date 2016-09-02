using System.Collections.Generic;
using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.Queries
{
    public class SearchJobsQuery : IRequest<IEnumerable<Job>>
    {
        public SearchJobsQuery(int cash, string title)
        {
            Cash = cash;
            Title = title;
        }

        public int Cash { get; set; }

        public string Title { get; set; }
    }
}
