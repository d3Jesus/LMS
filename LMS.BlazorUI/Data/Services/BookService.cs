using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("local");
            var response = await client.GetFromJsonAsync<ServiceResponse<IEnumerable<Book>>>("books");

            return response.ResponseData;
        }
    }
}
