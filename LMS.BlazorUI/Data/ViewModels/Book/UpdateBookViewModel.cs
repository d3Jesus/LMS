using System.ComponentModel.DataAnnotations;
using CinosoftErp.Extensions.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace LMS.BlazorUI.Data.ViewModels.Book;

public class UpdateBookViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This field is required.")]
    public string Title{ get; set; }

    [Required(ErrorMessage = "This field is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    public int Edition { get; set; } = 1;

    [Required(ErrorMessage = "This field is required.")]
    public string ISBN { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    public int CategoryId { get; set; } = 1;

    [Required(ErrorMessage = "This field is required.")]
    public decimal Price { get; set; }
    [Required]
    public int CopiesAvailable { get; set; } = 1;
    [Required]
    public string Status { get; set; }
    [MaxSize(512000, ErrorMessage = "This file size extends the maximum size of 512kb.")]
    public virtual long Size { get; set; }
    public virtual List<BookAuthorsViewModel> Authors { get; set; } 
    public virtual IBrowserFile File { get; set; }
}