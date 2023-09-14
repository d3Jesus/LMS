using System.ComponentModel.DataAnnotations;

namespace LMS.CoreBusiness.Requests.Account
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage = "Please, provide your account email.")]
        [EmailAddress(ErrorMessage = "The provided email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, provide your account password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
