
using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Extensions;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorUI.Pages.Dashboard.Librarians
{
    public partial class ListLibrarians
    {
        private List<Librarian> allLibrarians;
        private List<Librarian> listOfLibrarians;
        private const int _itemsPerPage = 25;
        private int _totalPages;
        private int _page = 0;
        private TableSorting sort = new();
        [Inject]
        public ILibrarianService Service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            allLibrarians = (await Service.GetAsync()).ResponseData.ToList();
            if (allLibrarians is not null)
            {
                _totalPages = (int)Math.Ceiling((double)allLibrarians.Count / _itemsPerPage);
                Paginate();
            }
        }

        void HandlePageChange(int pageNumber)
        {
            _page = pageNumber;
            if (listOfLibrarians is not null)
                Paginate();
        }

        void Paginate()
        {
            listOfLibrarians = allLibrarians
                    .Skip((_page - 1) * _itemsPerPage)
                    .Take(_itemsPerPage)
                    .ToList();

            StateHasChanged();
        }

        private void SortByColumn(string columnName)
        {
            allLibrarians = sort.SortByColumn(allLibrarians, columnName);
            DisplaySorted();
        }

        private void DisplaySorted()
        {
            listOfLibrarians = allLibrarians
                        .Skip((_page - 1) * _itemsPerPage)
                        .Take(_itemsPerPage)
                        .ToList();
            StateHasChanged();
        }
    }
}
