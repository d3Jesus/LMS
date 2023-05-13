namespace LMS.Application.ViewModels.Book
{
    public record GetBookDto (int id, string title, string description, int editions, string isbn, int category, string imageUrl, DateTime dateCreated);
}
