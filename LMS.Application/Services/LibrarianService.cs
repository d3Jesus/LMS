using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Librarian;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository _repository;
        private readonly IMapper _mapper;

        public LibrarianService(IMapper mapper, ILibrarianRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetLibrarianDto>> CreateAsync(AddLibrarianDto librarian)
        {
            var serviceResponse = new ServiceResponse<GetLibrarianDto>();
            try
            {
                var mapper = _mapper.Map<Librarian>(librarian);
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetLibrarianDto>(response);
                serviceResponse.Message = $"Librarian with name {string.Concat(librarian.firstName, " ", librarian.lastName)} added successfully!";
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

                serviceResponse.Message = "Librarian deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetLibrarianDto>>> GetAsync(bool wasDeleted)
        {
            var result = await _repository.GetAsync(wasDeleted);

            var serviceResponse = new ServiceResponse<IEnumerable<GetLibrarianDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetLibrarianDto>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLibrarianDto>> GetByAsync(int id)
        {
            var result = await _repository.GetByAsync(id);

            var serviceResponse = new ServiceResponse<GetLibrarianDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Librarian with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetLibrarianDto>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLibrarianDto>> GetByAsync(string name)
        {
            var result = await _repository.GetByAsync(name);

            var serviceResponse = new ServiceResponse<GetLibrarianDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Librarian with name {name} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetLibrarianDto>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLibrarianDto>> UpdateAsync(GetLibrarianDto librarian)
        {
            var serviceResponse = new ServiceResponse<GetLibrarianDto>();

            try
            {
                var mappedLibrarian = _mapper.Map<Librarian>(librarian);
                var result = await _repository.UpdateAsync(mappedLibrarian);

                serviceResponse.ResponseData = _mapper.Map<GetLibrarianDto>(result);
                serviceResponse.Message = "Librarian updated!";
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
