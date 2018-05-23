using System.ComponentModel.DataAnnotations;

namespace UserDashboard.Models
{
    public class SigninViewModel {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string Email { get; set; }


        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}