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

		public async Task<ServiceResponse<Author>> CreateAsync(Author author)
        {
            author.WasDeleted = false;
            var result = await _httpClient.PostAsJsonAsync("authors", author);
			return await result.Content.ReadFromJsonAsync<ServiceResponse<Author>>();
		}

		public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var authors = await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<Author>>>("authors");

            return authors.ResponseData;
        }

        public async Task<ServiceResponse<Author>> GetByAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ServiceResponse<Author>>($"authors/{id}");
        }

        public async Task<ServiceResponse<Author>> UpdateAsync(Author author)
        {
            var result = await _httpClient.PutAsJsonAsync("authors", author);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Author>>();
        }
    }
}
