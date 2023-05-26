namespace LMS.CoreBusiness.ViewModels
{
    public record AddBookViewModel
        (
            string title, 
            string description, 
            int edition, 
            string isbn, 
            int categoryId, 
            string imageUrl, 
            DateTime dateCreated, 
            decimal price, 
            List<int> authors
        );
}
