using LMS.Application.ViewModels.Book;

namespace LMS.Application.ViewModels.Purchase;

public record struct GetPurchaseItemsDto(int PurchaseId, int BookId, GetBookDto Book, int NumberOfCopies, decimal UnitPrice, decimal GrossPrice);