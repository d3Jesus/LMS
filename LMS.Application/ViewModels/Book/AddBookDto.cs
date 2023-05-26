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
            DateTime dateCreated, 
            decimal price,
            List<int> authors
        );
}
