using System.ComponentModel.DataAnnotations;

namespace CashJobSite.Web.Models
{
    public class ApplyForJobViewModel
    {
        [Required]
        public int JobId { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public int JobCash { get; set; }

        [Required]
        [Display(Name = "Your Name")]
        public string CandidateName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string CandidateEmail { get; set; }

        [Required]
        [Display(Name = "Information about you")]
        public string CandidateInfo { get; set; }
    }
}