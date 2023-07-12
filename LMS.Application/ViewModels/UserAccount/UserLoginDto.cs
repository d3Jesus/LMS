using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.UserAccount
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Please, enter your email to login.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter your account password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
