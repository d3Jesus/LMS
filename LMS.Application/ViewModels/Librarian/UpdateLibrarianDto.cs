using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Librarian;

public class UpdateLibrarianDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The librarian's first name is required.")]
    [StringLength(50, ErrorMessage = "This field only allows {1} characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "The librarian's last name is required.")]
    [StringLength(50, ErrorMessage = "This field only allows {1} characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "The librarian's address is required.")]
    [StringLength(50, ErrorMessage = "This field only allows {1} characters.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "The librarian's email is required.")]
    [StringLength(50, ErrorMessage = "This field only allows {1} characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The librarian's phone number is required.")]
    [StringLength(50, ErrorMessage = "This field only allows {1} characters.")]
    public string PhoneNumber { get; set; }
}