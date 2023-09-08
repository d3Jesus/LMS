using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Author;

public class UpdateAuthorDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The author's first name is required.")]
    [StringLength(20, ErrorMessage = "This field only allows {1} characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "The author's last name is required.")]
    [StringLength(20, ErrorMessage = "This field only allows {1} characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "The author's nationality is required.")]
    public string Nationality { get; set; }
}
