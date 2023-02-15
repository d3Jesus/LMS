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

        public async Task<ServiceResponse<GetBookViewModel>> AddAsync(AddBookViewModel book)
        {
            var serviceResponse = new ServiceResponse<GetBookViewModel>();
            try
            {
                var mapper = _mapper.Map<Book>(book);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetBookViewModel>(response);
                serviceResponse.Message = $"Book added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetBookViewModel book)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<Book>(book);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Book deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetBookViewModel>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetBookViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetBookViewModel>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookViewModel>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            var serviceResponse = new ServiceResponse<GetBookViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Book with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetBookViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookViewModel>> GetByTitleAsync(string title)
        {
            var result = await _repository.GetByTitleAsync(title);

            var serviceResponse = new ServiceResponse<GetBookViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Book with title {title} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetBookViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookViewModel>> UpdateAsync(GetBookViewModel book)
        {
            var serviceResponse = new ServiceResponse<GetBookViewModel>();

            try
            {
                var mappedBook = _mapper.Map<Book>(book);
                var result = await _repository.UpdateAsync(mappedBook);

                serviceResponse.ResponseData = _mapper.Map<GetBookViewModel>(result);
                serviceResponse.Message = "Book updated!";
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
