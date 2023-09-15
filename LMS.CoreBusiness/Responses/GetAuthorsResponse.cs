using LMS.CoreBusiness.Responses.Book;

namespace LMS.CoreBusiness.Responses;

public record struct GetAuthorsResponse(int Id,
                                        string FirstName,
                                        string LastName,
                                        bool WasDeleted,
                                        string Nationality,
                                        List<GetBookResumeResponse> Books);