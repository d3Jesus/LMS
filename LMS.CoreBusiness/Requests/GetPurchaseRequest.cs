namespace LMS.CoreBusiness.Requests;

public record GetPurchaseRequest(DateTime FromDate,
                               DateTime ToDate,
                               int CurrentPage,
                               int PageSize,
                               string SortColumn,
                               string SortOrder = "desc");