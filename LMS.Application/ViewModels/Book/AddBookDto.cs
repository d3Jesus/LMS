namespace LMS.Application.ViewModels.Book
{
    public record AddBookDto (string title, string description, int editions, string isbn, int category, string imageUrl, DateTime dateCreated, decimal price);
}
