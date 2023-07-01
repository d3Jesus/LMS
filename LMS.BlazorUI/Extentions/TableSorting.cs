namespace LMS.BlazorUI.Extensions;

public class TableSorting
{
    private string sortColumn = string.Empty;
    private bool isAscending = true;
    public List<T> SortByColumn<T>(List<T> items, string columnName)
    {
        if (sortColumn.Equals(columnName))
            isAscending = !isAscending;
        else
        {
            sortColumn = columnName;
            isAscending = true;
        }

        return isAscending ?
            items.OrderBy(item => GetPropertyValue(item, sortColumn)).ToList() :
            items.OrderByDescending(item => GetPropertyValue(item, sortColumn))
            .ToList();
    }

    private object GetPropertyValue<T>(T item, string propertyName)
    {
        var propertyInfo = typeof(T).GetProperty(propertyName);
        if (propertyInfo is null)
            return null;

        return propertyInfo.GetValue(item);
    }
}
