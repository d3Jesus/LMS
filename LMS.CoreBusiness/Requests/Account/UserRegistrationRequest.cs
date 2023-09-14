using System.ComponentModel.DataAnnotations;

namespace LMS.CoreBusiness.Requests.Account;

public class UserRegistrationRequest
{
    [Required(ErrorMessage = "The librarian ID is required.")]
    public int LibrarianId { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [StringLength(20, ErrorMessage = "This field only allows {1} characters.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "The provided email address is not valid.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm your password.")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Role is required.")]
    public string Role { get; set; }
}
