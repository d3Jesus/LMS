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

        [HttpPost]
        public async Task<IActionResult> Register(AccountDto user)
        {
            return Ok(await _userAccountService.Register(user));
        }
    }
}
