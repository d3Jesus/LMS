
using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.ViewModels.Purchase;
using LMS.BlazorUI.Extensions;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorUI.Pages.Dashboard.Purchases
{
    public partial class ListPurchases
    {
        private List<GetPurchaseViewModel> allPurchases;
        private List<GetPurchaseViewModel> purchases;
        private const int _itemsPerPage = 25;
        private int _totalPages;
        private int _page = 0;
        private TableSorting sort = new();
        [Inject]
        public IPurchaseService Service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            DateTime date = DateTime.Now;
            allPurchases = (await Service.GetAsync(date.Date, date.Date.AddMonths(1), 10)).ToList();
            if (allPurchases is not null)
            {
                _totalPages = (int)Math.Ceiling((double)allPurchases.Count / _itemsPerPage);
                Paginate();
            }
        }

        void HandlePageChange(int pageNumber)
        {
            _page = pageNumber;
            if (purchases is not null)
                Paginate();
        }

        void Paginate()
        {
            purchases = allPurchases
                    .Skip((_page - 1) * _itemsPerPage)
                    .Take(_itemsPerPage)
                    .ToList();

            StateHasChanged();
        }

        private void SortByColumn(string columnName)
        {
            allPurchases = sort.SortByColumn(allPurchases, columnName);
            DisplaySorted();
        }

        private void DisplaySorted()
        {
            purchases = allPurchases
                        .Skip((_page - 1) * _itemsPerPage)
                        .Take(_itemsPerPage)
                        .ToList();
            StateHasChanged();
        }
    }
}
