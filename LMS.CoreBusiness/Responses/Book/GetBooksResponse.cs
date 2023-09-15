namespace LMS.CoreBusiness.Responses.Book;

public record struct GetBooksResponse(int Id,
                                      string Title,
                                      string Description,
                                      int Edition,
                                      string ISBN,
                                      GetCategoryResponse Category,
                                      string ImageUrl);
