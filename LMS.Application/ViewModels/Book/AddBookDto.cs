using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Book;

public record AddBookDto
{
    [Required(ErrorMessage = "The book's title is required.")]
    [StringLength(100,ErrorMessage = "This field only allows {1} characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "The book's decription is required.")]
    [StringLength(100, ErrorMessage = "This field only allows {1} characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "The book's edition is required.")]
    public int Edition { get; set; } = 0;

    [Required(ErrorMessage = "The book's ISBN is required.")]
    [StringLength(50, ErrorMessage = "This field only allows {1} characters.")]
    public string Isbn { get; set; }

    [Required(ErrorMessage = "The book's category is required.")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "The book's title is required.")]
    [StringLength(50, ErrorMessage = "This field only allows {1} characters.")]
    public string ImageUrl { get; set; }
}
