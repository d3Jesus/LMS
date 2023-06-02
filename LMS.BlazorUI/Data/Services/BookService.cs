using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Data.Models.ViewModels;

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

        public async Task<ServiceResponse<Book>> CreateAsync(Book model)
        {
            var result = await _httpClient.PostAsJsonAsync("books", model);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
        }

        public async Task<IEnumerable<GetBookViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<GetBookViewModel>>>("books");

            return response.ResponseData;
        }

        public async Task<IEnumerable<GetBookViewModel>> GetAllByAsync(int categoryId)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<GetBookViewModel>>>($"books/getByCategory/{categoryId}");
            return response.ResponseData;
        }

        public async Task<Book> GetByAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Book>>($"books/{id}");
            return response.ResponseData;
        }

        public async Task<ServiceResponse<Book>> UpdateAsync(Book model)
        {
            var result = await _httpClient.PutAsJsonAsync("books", model);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
        }
    }
}
