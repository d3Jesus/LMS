using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Services
{
    public class LibrarianService : ILibrarianService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public LibrarianService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("local");
        }

        public async Task<ServiceResponse<Librarian>> CreateAsync(Librarian librarian)
        {
            var result = await _httpClient.PostAsJsonAsync("librarians", librarian);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Librarian>>();
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"librarians/{id}");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<IEnumerable<Librarian>>> GetAsync()
        {
            return await _httpClient.GetFromJsonAsync<ServiceResponse<IEnumerable<Librarian>>>("librarians");
        }

        public async Task<ServiceResponse<Librarian>> GetByAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ServiceResponse<Librarian>>($"librarians/{id}");
        }

        public async Task<ServiceResponse<Librarian>> UpdateAsync(Librarian librarian)
        {
            var result = await _httpClient.PutAsJsonAsync("librarians", librarian);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Librarian>>();
        }
    }
}
