using System.Web.Mvc;
using CashJobSite.Application;
using CashJobSite.Web.Models;

namespace CashJobSite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobService _jobService;

        public HomeController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public ActionResult Index()
        {
            var allJobs = _jobService.FindAllJobs();

            var viewModel = new HomePageViewModel { Jobs = allJobs, SearchForm = new SearchFormModel() };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Index([Bind(Prefix = "SearchForm")]SearchFormModel search)
        {
            var searchResults = _jobService
                .SearchJobs(search.Title, search.Cash);

            var viewModel = new HomePageViewModel { Jobs = searchResults, SearchForm = search };

            return View(viewModel);
        }
    }
}