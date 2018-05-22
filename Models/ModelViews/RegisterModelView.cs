using System.ComponentModel.DataAnnotations;

namespace UserDashboard.Models
{
    public class RegisterViewModel {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="Passwords must match.")]
        [DataType(DataType.Password)]
        [Display(Name="Conform Password")]
        public string ConfirmPassword { get; set; }
    }
}