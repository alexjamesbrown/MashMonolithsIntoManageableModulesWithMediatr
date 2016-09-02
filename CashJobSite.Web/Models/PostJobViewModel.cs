using System.ComponentModel.DataAnnotations;

namespace CashJobSite.Web.Models
{
    public class PostJobViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Cash { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}