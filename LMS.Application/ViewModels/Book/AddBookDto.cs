namespace LMS.Application.ViewModels.Book
{
    public record AddBookDto 
        (
            string title, 
            string description, 
            int editions, 
            string isbn, 
            int categoryId, 
            string imageUrl, 
            decimal price,
            List<int> authors
        );
}
