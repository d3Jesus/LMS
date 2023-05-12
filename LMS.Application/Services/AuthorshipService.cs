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

        public async Task<ServiceResponse<GetAuthorshipDto>> AddAsync(AddAuthorshipDto authorship)
        {
            var serviceResponse = new ServiceResponse<GetAuthorshipDto>();
            try
            {
                var mapper = _mapper.Map<Authorship>(authorship);
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetAuthorshipDto>(response);
                serviceResponse.Message = $"Authorship added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorshipDto>> UpdateAsync(GetAuthorshipDto authorship)
        {
            var serviceResponse = new ServiceResponse<GetAuthorshipDto>();

            try
            {
                var mappedAuthorship = _mapper.Map<Authorship>(authorship);
                var result = await _repository.UpdateAsync(mappedAuthorship);

                serviceResponse.ResponseData = _mapper.Map<GetAuthorshipDto>(result);
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
