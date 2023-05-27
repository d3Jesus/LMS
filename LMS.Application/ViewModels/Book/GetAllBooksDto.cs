namespace LMS.Application.ViewModels.Book
{
    public record GetAllBooksDto
        (
            int id,
            string title,
            string description,
            int edition,
            string isbn,
            string categoryName,
            string imageUrl,
            DateTime dateCreated,
            decimal price
        );
}
