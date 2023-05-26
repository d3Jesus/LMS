namespace LMS.CoreBusiness.ViewModels
{
    public record GetBookViewModel
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
