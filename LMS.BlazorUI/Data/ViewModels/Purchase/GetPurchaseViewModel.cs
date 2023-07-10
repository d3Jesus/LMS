namespace LMS.BlazorUI.Data.ViewModels.Purchase;

public record struct GetPurchaseViewModel (int id, DateTime datePurchased, string customerName, string librarianName);

