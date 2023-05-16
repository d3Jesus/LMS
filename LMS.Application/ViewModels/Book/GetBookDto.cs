namespace LMS.Application.ViewModels.Book
{
    public record GetBookDto (int id, string title, string description, int edition, string isbn, int categoryId, string imageUrl, DateTime dateCreated, decimal price);
}
