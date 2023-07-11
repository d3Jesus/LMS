using System.ComponentModel.DataAnnotations;

namespace LMS.BlazorUI.Data.ViewModels.Account
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "The password should must have 8 characters minimum.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}
