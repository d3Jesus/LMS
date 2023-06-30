namespace LMS.Application.ViewModels.Purchase;

public record AddPurchaseItemsDto(int PurchasedId, int BookId, int NumberOfCopies, decimal UnitPrice, decimal GrossPrice, string Status);