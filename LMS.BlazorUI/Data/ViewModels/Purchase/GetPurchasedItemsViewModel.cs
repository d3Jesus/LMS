namespace LMS.BlazorUI.Data.ViewModels.Purchase;

public record struct GetPurchasedItemsViewModel (int purchaseId, int bookId, decimal unitPrice, int numberOfCopies, decimal grossPrice);

