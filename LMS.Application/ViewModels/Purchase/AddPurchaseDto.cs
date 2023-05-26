namespace LMS.Application.ViewModels.Loan
{
    public record AddPurchaseDto(int bookId, int librarianId, decimal totalPayed, int numberOfCopies, decimal basePrice, decimal itemPurchasedPrice);
}
