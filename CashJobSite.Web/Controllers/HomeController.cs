using System.Web.Mvc;
using CashJobSite.Application;
using CashJobSite.Application.Queries;
using CashJobSite.Web.Models;
using MediatR;

namespace CashJobSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IMediator _mediator;

        public HomeController(IJobService jobService, IMediator mediator)
        {
            _jobService = jobService;
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            var allJobs = _mediator.Send(new FindAllJobsQuery());

            var viewModel = new HomePageViewModel { Jobs = allJobs, SearchForm = new SearchFormModel() };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Index([Bind(Prefix = "SearchForm")]SearchFormModel search)
        {
            var searchResults = _mediator.Send(new SearchJobsQuery(search.Cash, search.Title));

            var viewModel = new HomePageViewModel { Jobs = searchResults, SearchForm = search };

            return View(viewModel);
        }
    }
}