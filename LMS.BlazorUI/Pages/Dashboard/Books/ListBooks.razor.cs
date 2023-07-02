
using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models.ViewModels;
using LMS.BlazorUI.Extensions;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorUI.Pages.Dashboard.Books
{
    public partial class ListBooks
    {
        // If the operations was successful or not
        [Parameter]
        public string responseStatus { get; set;}
        private List<GetBookViewModel> allBooks;
        private List<GetBookViewModel> books;
        private const int _itemsPerPage = 25;
        private int _totalPages;
        private int _page = 0;
        private TableSorting sort = new();
        [Inject]
        public IBookService Service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            allBooks = (await Service.GetAllAsync()).ToList();
            if (allBooks is not null)
            {
                _totalPages = (int)Math.Ceiling((double)allBooks.Count / _itemsPerPage);
                Paginate();
            }
        }

        void HandlePageChange(int pageNumber)
        {
            _page = pageNumber;
            if (books is not null)
                Paginate();
        }

        void Paginate()
        {
            books = allBooks
                    .Skip((_page - 1) * _itemsPerPage)
                    .Take(_itemsPerPage)
                    .ToList();

            StateHasChanged();
        }

        private void SortByColumn(string columnName)
        {
            allBooks = sort.SortByColumn(allBooks, columnName);
            DisplaySorted();
        }

        private void DisplaySorted()
        {
            books = allBooks
                        .Skip((_page - 1) * _itemsPerPage)
                        .Take(_itemsPerPage)
                        .ToList();
            StateHasChanged();
        }
    }
}
