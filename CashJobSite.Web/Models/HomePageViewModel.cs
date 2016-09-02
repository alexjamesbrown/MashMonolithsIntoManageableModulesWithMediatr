using System.Collections.Generic;
using CashJobSite.Models;

namespace CashJobSite.Web.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Job> Jobs { get; set; }
        public SearchFormModel SearchForm { get; set; }
    }
}