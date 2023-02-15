using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Authorship;
using LMS.Application.ViewModels;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class AuthorshipService : IAuthorshipService
    {
        private readonly IAuthorshipRepository _repository;
        private readonly IMapper _mapper;

        public AuthorshipService(IMapper mapper, IAuthorshipRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetAuthorshipViewModel>> AddAsync(AddAuthorshipViewModel authorship)
        {
            var serviceResponse = new ServiceResponse<GetAuthorshipViewModel>();
            try
            {
                var mapper = _mapper.Map<Authorship>(authorship);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetAuthorshipViewModel>(response);
                serviceResponse.Message = $"Authorship added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetAuthorshipViewModel authorship)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<Authorship>(authorship);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Authorship deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorshipViewModel>> UpdateAsync(GetAuthorshipViewModel authorship)
        {
            var serviceResponse = new ServiceResponse<GetAuthorshipViewModel>();

            try
            {
                var mappedAuthorship = _mapper.Map<Authorship>(authorship);
                var result = await _repository.UpdateAsync(mappedAuthorship);

                serviceResponse.ResponseData = _mapper.Map<GetAuthorshipViewModel>(result);
                serviceResponse.Message = "Authorship updated!";
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
