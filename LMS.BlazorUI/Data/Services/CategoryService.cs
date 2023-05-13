using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Category>> GetAsync()
        {
            var client = _httpClientFactory.CreateClient("local");
            var categories = await client.GetFromJsonAsync<ServiceResponse<IEnumerable<Category>>>("categories");

            return categories.ResponseData;
        }
    }
}
