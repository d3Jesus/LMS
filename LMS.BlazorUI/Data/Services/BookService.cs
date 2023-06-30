using BlazorInputFile;
using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Data.Models.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;

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
                book.AuthorsIds.Add(author.AuthorId);
            }
            var result = await _httpClient.PostAsJsonAsync("books", book);

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

        public async Task<List<GetBookViewModel>> GetByAsync(string title)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<GetBookViewModel>>>($"books/getByTitle/{title}");
            return response.ResponseData;
        }

        public async Task<ServiceResponse<Book>> UpdateAsync(AddBookViewModel model)
        {
            var result = await _httpClient.PutAsJsonAsync("books", model);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
        }

        private async Task<string> GetImageUrlAsync(IBrowserFile fileEntry)
        {
            const long MAX_FILE_SIZE = 1024 * 100;
            using (var memStream = new MemoryStream())
            {
                string fileName = fileEntry.Name;
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", fileName);

                await using FileStream fs = new(path, FileMode.Create);
                await fileEntry.OpenReadStream(MAX_FILE_SIZE).CopyToAsync(fs);

                return $"/img/{fileName}";
                //try
                //{

                //}
                //catch (Exception ex)
                //{
                //    Logger.LogError("File: {Filename} Error: {Error}",
                //        fileEntry.Name, ex.Message);
                //}
                //Guid guid = Guid.NewGuid();
                //string uniqueFileName = $"{fileEntry.Name}";

                //var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", uniqueFileName);

                //await fileEntry.Data.CopyToAsync(memStream);

                //using (FileStream fileStream = new FileStream(path, FileMode.Create))
                //{
                //    memStream.WriteTo(fileStream);
                //}

                //return uniqueFileName;
            }
        }
    }
}
