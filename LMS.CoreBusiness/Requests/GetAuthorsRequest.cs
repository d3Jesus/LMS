namespace LMS.CoreBusiness.Requests;

public record GetAuthorsRequest(int CurrentPage,
                                int PageSize,
                                string SearchTerm = "",
                                string SortColumn = "id",
                                string SortOrder = "desc",
                                bool WasDeleted = false);