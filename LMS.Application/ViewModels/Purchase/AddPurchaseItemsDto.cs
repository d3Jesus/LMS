namespace LMS.Application.ViewModels.Purchase;

public record AddPurchaseItemsDto(int BookId, int NumberOfCopies, decimal UnitPrice, decimal GrossPrice);