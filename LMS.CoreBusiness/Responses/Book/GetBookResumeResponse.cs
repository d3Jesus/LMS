namespace LMS.CoreBusiness.Responses.Book;

public record struct GetBookResumeResponse(int Id,
                                           string Title,
                                           string Description);
