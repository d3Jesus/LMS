using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public AuthorService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("local");
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var authors = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<Author>>>("authors");

            return authors.ResponseData;
        }
    }
}
