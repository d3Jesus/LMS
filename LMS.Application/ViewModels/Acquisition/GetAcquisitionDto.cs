using LMS.Application.ViewModels.Book;

namespace LMS.Application.ViewModels.Acquisition;

public record struct GetAcquisitionDto(string Id,
                                         string LibrarianName,
                                         DateTime DateRegistered,
                                         int TotalItems,
                                         string Status,
                                         GetBookDto Book,
                                         List<GetAcquisitionItemsDto> Items);
