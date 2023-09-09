using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Book;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using Mapster;

namespace LMS.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository) => _repository = repository;

        public async Task<ServiceResponse<GetBookDto>> CreateAsync(AddBookDto bookDto)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            try
            {
                var book = bookDto.Adapt<Book>();
                var response = await _repository.CreateAsync(book);

                serviceResponse.ResponseData = response.Adapt<GetBookDto>();
                serviceResponse.Message = "Book added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                await _repository.DeleteAsync(id);

                serviceResponse.Message = "Book deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetBookDto>>()
            {
                ResponseData = result.Adapt<IEnumerable<GetBookDto>>()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAsync(string title)
        {
            var result = await _repository.GetAsync(title);

            var serviceResponse = new ServiceResponse<IEnumerable<GetBookDto>>();
            if (result is null)
            {
                serviceResponse.Message = $"Book with title {title} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<IEnumerable<GetBookDto>>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAsync(int category)
        {
            var result = await _repository.GetAsync(category);

            var serviceResponse = new ServiceResponse<IEnumerable<GetBookDto>>()
            {
                ResponseData = result.Adapt<IEnumerable<GetBookDto>>()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookDto>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByAsync(id);

            var serviceResponse = new ServiceResponse<GetBookDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Book with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<GetBookDto>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookDto>> UpdateAsync(UpdateBookDto bookDto)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            try
            {
                var book = bookDto.Adapt<Book>();
                var response = await _repository.UpdateAsync(book);

                serviceResponse.ResponseData = response.Adapt<GetBookDto>();
                serviceResponse.Message = "Book updated successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}
