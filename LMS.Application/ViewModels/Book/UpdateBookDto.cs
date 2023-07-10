namespace LMS.Application.ViewModels.Book
{
    public record UpdateBookDto
        (
            int id,
            string title,
            string description,
            int edition,
            string isbn,
            int categoryId,
            string imageUrl,
            decimal price,
            string _status,
            int _copiesAvailable,
            List<int> authors
        );
}
