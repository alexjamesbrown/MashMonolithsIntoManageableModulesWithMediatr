using CashJobSite.Models;
using MediatR;

namespace CashJobSite.Application.Queries
{
    public class GetJobByIdQuery : IRequest<Job>
    {
        public int Id { get; set; }

        public GetJobByIdQuery(int id)
        {
            Id = id;
        }
    }
}
