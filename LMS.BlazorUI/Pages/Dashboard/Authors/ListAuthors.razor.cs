
using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Extensions;

namespace LMS.BlazorUI.Pages.Dashboard.Authors
{
    public partial class ListAuthors
    {
        private List<Author> allAuthors;
        private List<Author> authors;
        private const int _itemsPerPage = 25;
        private int _totalPages;
        private int _page = 0;
        private TableSorting sort = new();

        protected override async Task OnInitializedAsync()
        {
            var result = await Service.GetAllAsync();
            allAuthors = result.ToList();
            if (allAuthors is not null)
            {
                _totalPages = (int)Math.Ceiling((double)allAuthors.Count / _itemsPerPage);
                Paginate();
            }
        }

        void HandlePageChange(int pageNumber)
        {
            _page = pageNumber;
            if (authors is not null)
                Paginate();
        }

        void Paginate()
        {
            authors = allAuthors
                    .Skip((_page - 1) * _itemsPerPage)
                    .Take(_itemsPerPage)
                    .ToList();

            StateHasChanged();
        }

        private void SortByColumn(string columnName)
        {
            allAuthors = sort.SortByColumn(allAuthors, columnName);
            DisplaySorted();
        }

        private void DisplaySorted()
        {
            authors = allAuthors
                        .Skip((_page - 1) * _itemsPerPage)
                        .Take(_itemsPerPage)
                        .ToList();
            StateHasChanged();
        }
    }
}