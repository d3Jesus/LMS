using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public BookService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("local");
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<Book>>>("books");

            return response.ResponseData;
        }

        public async Task<IEnumerable<Book>> GetAllByAsync(int categoryId)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<Book>>>($"books/getByCategory/{categoryId}");
            return response.ResponseData;
        }

        public async Task<Book> GetByAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Book>>($"books/{id}");
            return response.ResponseData;
        }
    }
}
