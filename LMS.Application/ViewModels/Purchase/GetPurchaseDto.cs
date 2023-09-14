using LMS.Application.ViewModels.Librarian;

namespace LMS.Application.ViewModels.Purchase;

public record struct GetPurchaseDto(int Id,
                                    int LibrarianId,
                                    GetLibrarianDto Librarian,
                                    DateTime DatePurchased,
                                    decimal TotalPayed,
                                    IEnumerable<GetPurchaseItemsDto> PurchaseItems);