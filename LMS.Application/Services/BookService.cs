using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Book;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IMapper mapper, IBookRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetBookDto>> CreateAsync(AddBookDto model)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            try
            {
                var book = _mapper.Map<Book>(model);
                var response = await _repository.CreateAsync(book);

                serviceResponse.ResponseData = _mapper.Map<GetBookDto>(response);
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
                ResponseData = _mapper.Map<IEnumerable<GetBookDto>>(result)
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

            serviceResponse.ResponseData = _mapper.Map<IEnumerable<GetBookDto>>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAsync(int category)
        {
            var result = await _repository.GetAsync(category);

            var serviceResponse = new ServiceResponse<IEnumerable<GetBookDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetBookDto>>(result)
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

            serviceResponse.ResponseData = _mapper.Map<GetBookDto>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookDto>> UpdateAsync(UpdateBookDto model)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            try
            {
                var book = _mapper.Map<Book>(model);
                var response = await _repository.UpdateAsync(book);

                serviceResponse.ResponseData = _mapper.Map<GetBookDto>(response);
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
