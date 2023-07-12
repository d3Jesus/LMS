using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.UserAccount
{
    public class UserRegistrationDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmedPassword { get; set; }

        public string Role { get; set; }
    }
}
