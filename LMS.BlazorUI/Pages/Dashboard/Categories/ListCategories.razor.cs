
using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LMS.BlazorUI.Pages.Dashboard.Categories
{
    public partial class ListCategories
    {
        // If the operations was successful or not
        [Parameter]
        public string responseStatus { get; set;}
        private List<Category> allCategories;
        private List<Category> categories;
        private const int _itemsPerPage = 25;
        private int _totalPages;
        private int _page = 0;
        private TableSorting sort = new();
        
        [Inject]
        public IJSRuntime JS { get; set; }
        [Inject]
        public ICategoryService Service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await Service.GetAsync();
            allCategories = result.ToList();
            if (allCategories is not null)
            {
                _totalPages = (int)Math.Ceiling((double)allCategories.Count / _itemsPerPage);
                Paginate();
            }
        }

        void HandlePageChange(int pageNumber)
        {
            _page = pageNumber;
            if (categories is not null)
                Paginate();
        }

        void Paginate()
        {
            categories = allCategories
                    .Skip((_page - 1) * _itemsPerPage)
                    .Take(_itemsPerPage)
                    .ToList();

            StateHasChanged();
        }

        private void SortByColumn(string columnName)
        {
            allCategories = sort.SortByColumn(allCategories, columnName);
            DisplaySorted();
        }

        private void DisplaySorted()
        {
            categories = allCategories
                        .Skip((_page - 1) * _itemsPerPage)
                        .Take(_itemsPerPage)
                        .ToList();
            StateHasChanged();
        }
    }
}
