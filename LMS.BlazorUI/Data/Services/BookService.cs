using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Data.ViewModels.Book;
using Microsoft.AspNetCore.Components.Forms;

namespace LMS.BlazorUI.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public BookService(IHttpClientFactory httpClientFactory, IWebHostEnvironment webHostEnvironment)
        {
            _httpClientFactory = httpClientFactory;
            _webHostEnvironment = webHostEnvironment;
            _httpClient = _httpClientFactory.CreateClient("local");
        }

        public async Task<ServiceResponse<Book>> CreateAsync(AddBookViewModel model)
        {
            Book book = new()
            {
                Title = model.Title,
                Description = model.Description,
                Edition = model.Edition,
                ISBN = model.ISBN,
                CategoryId = model.CategoryId,
                ImageUrl = await GetImageUrlAsync(model.File),
                DateCreated = DateTime.Now,
                Price = model.Price
            };
            foreach (var author in model.BookAuthors)
            {
                book.Authors.Add(author.AuthorId);
            }
            var result = await _httpClient.PostAsJsonAsync("books", book);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
        }

        public async Task DeleteAsync(int bookId)
        {
            await _httpClient.DeleteAsync($"books/{bookId}");
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

        public async Task<GetBookViewModel> GetByAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<GetBookViewModel>>($"books/{id}");
            return response.ResponseData;
        }

        public async Task<List<GetBookViewModel>> GetByAsync(string title)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<GetBookViewModel>>>($"books/getByTitle/{title}");
            return response.ResponseData;
        }

        public async Task<ServiceResponse<Book>> UpdateAsync(UpdateBookViewModel model)
        {
            var existingBook = await GetByAsync(model.Id);
            Book book = new()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Edition = model.Edition,
                ISBN = model.ISBN,
                CategoryId = model.CategoryId,
                ImageUrl = model.File is null ? existingBook.ImageUrl : await GetImageUrlAsync(model.File),
                Price = model.Price
            };
            foreach (var author in model.Authors)
            {
                book.Authors.Add(author.AuthorId);
            }
            var result = await _httpClient.PutAsJsonAsync("books", book);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
        }

        private async Task<string> GetImageUrlAsync(IBrowserFile fileEntry)
        {
            using (var memStream = new MemoryStream())
            {
                string fileName = fileEntry.Name;
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);

                using (FileStream fs = new(path, FileMode.Create))
                {
                    await fileEntry.OpenReadStream().CopyToAsync(fs);
                }

                return $"/img/{fileName}";
            }
        }
    }
}
