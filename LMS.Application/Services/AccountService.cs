using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.UserAccount;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.Requests.Account;
using Mapster;

namespace LMS.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository) => _repository = repository;

        public async Task<ServiceResponse<IEnumerable<RolesDto>>> GetRoles()
        {
            var result = await _repository.GetRolesAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<RolesDto>>()
            {
                ResponseData = result.Adapt<IEnumerable<RolesDto>>()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> Register(UserRegistrationDto model)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                UserRegistrationRequest newUser = model.Adapt<UserRegistrationRequest>();
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
        public async Task<ServiceResponse<string>> Login(UserLoginDto model)
        {
            var serviceResponse = new ServiceResponse<string>();
            try
            {
                UserLoginRequest loggin = model.Adapt<UserLoginRequest>();
                var response = await _repository.Login(loggin);

                serviceResponse.ResponseData = response;
                serviceResponse.Message = $"User logged in successfully!";
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
