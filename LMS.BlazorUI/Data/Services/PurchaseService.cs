using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Data.ViewModels.Purchase;

namespace LMS.BlazorUI.Data.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public PurchaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("local");
        }

        public async Task<ServiceResponse<GetPurchaseViewModel>> CreateAsync(AddPurchaseViewModel model)
        {
            Purchase purchase = new()
            {
                LibrarianId = 4,
                CustomerName = model.CustomerName,
                TotalPayed = model.TotalPayed
            };
            foreach (var item in model.Items)
            {
                PurchaseItems newItem = new()
                {
                    BookId = item.BookId,
                    NumberOfCopies = item.NumberOfCopies,
                    UnitPrice = item.UnitPrice,
                    GrossPrice = item.GrossPrice
                };
                purchase.Items.Add(newItem);
            }
            var result = await _httpClient.PostAsJsonAsync("purchases", purchase);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<GetPurchaseViewModel>>();
        }

        public async Task<IEnumerable<GetPurchaseViewModel>> GetAsync(DateTime initDate, DateTime endDate, int itemsPerPage)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<GetPurchaseViewModel>>>($"purchases/{initDate}/{endDate}/{itemsPerPage}");

            return response.ResponseData;
        }
    }
}