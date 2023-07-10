namespace LMS.Application.ViewModels.Book
{
    public record AddBookDto 
        (
            string title, 
            string description, 
            int edition, 
            string isbn, 
            int categoryId, 
            string imageUrl, 
            decimal price,
            string status,
            int copiesAvailable,
            List<int> authors
        );
}
