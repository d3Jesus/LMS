namespace LMS.CoreBusiness.Responses;

public record struct GetPurchaseResponse(int Id,
                              int LibrarianId,
                              DateTime DatePurchased,
                              decimal TotalPayed);
