using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Authorship;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/authorships")]
    [ApiController]
    public class AuthorshipController : ControllerBase
    {
        private readonly IAuthorshipService _service;
        public AuthorshipController(IAuthorshipService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAuthorshipViewModel model)
        {
            var response = await _service.AddAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetAuthorshipViewModel model)
        {
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }
    }
}
