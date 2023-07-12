using LMS.Application.Interfaces;
using LMS.Application.ViewModels.UserAccount;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _userAccountService;

        public AccountController(IAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _userAccountService.GetRoles());
        }

        /// <summary>
        /// Endpoint to register a user
        /// </summary>
        /// <param name="user">
        /// User DTO containing:
        ///     Username
        ///     Email
        ///     Password
        ///     ConfirmPassword
        /// </param>
        /// <returns>true on sucess and false otherwise</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto user)
        {
            return Ok(await _userAccountService.Register(user));
        }

        /// <summary>
        /// Endpoint to login a user
        /// </summary>
        /// <param name="user"> User DTO containing the user email and password.</param>
        /// <returns>token string on success and empty string otherwise</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            return Ok(await _userAccountService.Login(user));
        }
    }
}
