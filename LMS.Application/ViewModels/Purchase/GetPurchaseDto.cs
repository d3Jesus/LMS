namespace LMS.Application.ViewModels.Purchase
{
    public record GetPurchaseDto (int id, int librarianId, string customerName, DateTime datePurchased, decimal totalPayed);
}
