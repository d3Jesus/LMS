
namespace LMS.CoreBusiness.Helpers;

public class PagedList<TItems>
{
    public PagedList(List<TItems> items, int currentPage, int pageSize, int totalCount)
    {
        Items = items;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public List<TItems> Items { get; }

    public int CurrentPage { get; }

    public int PageSize { get; }

    public int TotalCount { get; }

    public bool HasNextPage => CurrentPage * PageSize < TotalCount;

    public bool HasPreviousPage => CurrentPage > 1;

    public static PagedList<TItems> CreateAsync(List<TItems> items, int currentPage, int pageSize, int totalCount)
        => new(items, currentPage, pageSize, totalCount);
}
