using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;
using LMS.Application.ViewModels.UserAccount;
using LMS.CoreBusiness.Entities.Accounts;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<RolesDto>>> GetRoles()
        {
            var result = await _repository.GetRolesAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<RolesDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<RolesDto>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> Register(AccountDto model)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                Account newUser = _mapper.Map<Account>(model);
                var response = await _repository.Register(newUser);

                serviceResponse.ResponseData = response;
                serviceResponse.Message = $"User created successfully!";
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
