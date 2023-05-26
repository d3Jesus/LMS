namespace LMS.CoreBusiness.ViewModels
{
    public record AddPurchaseViewModel(int bookId, int librarianId, decimal totalPayed, int numberOfCopies, decimal basePrice, decimal itemPurchasedPrice);
}
