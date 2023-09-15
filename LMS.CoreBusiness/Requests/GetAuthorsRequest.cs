namespace LMS.CoreBusiness.Requests;

public record GetAuthorsRequest(int CurrentPage,
                                int PageSize,
                                string SortColumn,
                                string SortOrder = "desc",
                                bool WasDeleted = false);