using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Data.ViewModels.Book;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace LMS.BlazorUI.Pages.Dashboard.Books;

public partial class UpdateBook
{
    [Inject]
    public IBookService Service { get; set; }
    [Inject]
    public ICategoryService CategoryService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    private UpdateBookViewModel book = new();
    private IEnumerable<Category> categories;
    private bool responseStatus;
    private string responseMessage;
    private string IsDisabled = string.Empty;
    [Parameter]
    public int id { get; set; }
    public List<string> bookStatus;

    protected override async Task OnParametersSetAsync()
    {
        bookStatus = new List<string>()
        {
            "Available"
        };
        categories = await CategoryService.GetAsync();
        var data = await Service.GetByAsync(id);
        book = new()
        {
            Id = data.Id,
            Title = data.Title,
            Description = data.Description,
            Edition = data.Edition,
            ISBN = data.ISBN,
            CategoryId = data.CategoryId,
            Price = data.Price,
            Authors = data.ListOfAuthors.Select(dt => new BookAuthorsViewModel()
            {
                AuthorId = dt.Id,
                AuthorName = string.Concat(dt.FirstName, " ", dt.LastName)
            })
            .ToList()
        };
    }

    private void SelectedAuthor(List<BookAuthorsViewModel> author)
    {
        book.Authors = author;
    }

    private void LoadFiles(InputFileChangeEventArgs e)
    {
        IBrowserFile browserFile = e.GetMultipleFiles(1).FirstOrDefault();
        book.File = browserFile;
        book.Size = browserFile.Size;
    }

    private async Task OnValidSubmit()
    {
        IsDisabled = "disabled";
        var result = await Service.UpdateAsync(book);
        responseStatus = result.Succeeded;
        responseMessage = result.Message;
        StateHasChanged();

        await Task.Delay(2000);
        NavigationManager.NavigateTo("books", true);
    }
}