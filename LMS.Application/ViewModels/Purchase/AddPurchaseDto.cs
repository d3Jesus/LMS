namespace LMS.Application.ViewModels.Purchase
{
    public record AddPurchaseDto(int librarianId, string customerName, decimal totalPayed, List<AddPurchaseItemsDto> items);
}
