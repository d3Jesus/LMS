using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Bookcase;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class BookcaseService : IBookcaseService
    {
        private readonly IBookcaseRepository _repository;
        private readonly IMapper _mapper;

        public BookcaseService(IMapper mapper, IBookcaseRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetBookcaseViewModel>> AddAsync(AddBookcaseViewModel bookcase)
        {
            var serviceResponse = new ServiceResponse<GetBookcaseViewModel>();
            try
            {
                var mapper = _mapper.Map<Bookcase>(bookcase);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetBookcaseViewModel>(response);
                serviceResponse.Message = $"Bookcase added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetBookcaseViewModel bookcase)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<Bookcase>(bookcase);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Bookcase deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetBookcaseViewModel>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetBookcaseViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetBookcaseViewModel>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookcaseViewModel>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            var serviceResponse = new ServiceResponse<GetBookcaseViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Bookcase with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetBookcaseViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookcaseViewModel>> UpdateAsync(GetBookcaseViewModel bookcase)
        {
            var serviceResponse = new ServiceResponse<GetBookcaseViewModel>();

            try
            {
                var mappedBookcase = _mapper.Map<Bookcase>(bookcase);
                var result = await _repository.UpdateAsync(mappedBookcase);

                serviceResponse.ResponseData = _mapper.Map<GetBookcaseViewModel>(result);
                serviceResponse.Message = "Bookcase updated!";
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
