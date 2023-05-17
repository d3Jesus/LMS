using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("local");
        }

        public async Task<ServiceResponse<Category>> CreateAsync(Category category)
        {
            var result = await _httpClient.PostAsJsonAsync("categories", category);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Category>>();
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var categories = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<Category>>>("categories");

            return categories.ResponseData;
        }
    }
}
