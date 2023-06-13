using BlazorInputFile;
using Microsoft.AspNetCore.Components.Forms;

namespace LMS.BlazorUI.Data.Models.ViewModels;

public class AddBookViewModel
{
    public string Title{ get; set; }
    public string Description { get; set; }
    public int Edition { get; set; }
    public string ISBN { get; set; }
    public int CategoryId { get; set; } = 1;
    public DateTime DateCreated { get; set; }
    public decimal Price { get; set; }
    public List<BookAuthorsViewModel> BookAuthors { get; set; } 
    public virtual IBrowserFile File { get; set; }
}
