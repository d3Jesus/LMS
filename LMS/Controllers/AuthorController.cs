using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("{name:alpha}")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await _service.GetByNameAsync(name));
        }

        [HttpGet("{nationality}")]
        public async Task<IActionResult> GetByNationality(string nationality)
        {
            return Ok(await _service.GetByNationalityAsync(nationality));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAuthorViewModel model)
        {   
            var response = await _service.AddAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetAuthorViewModel model)
        {   
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(GetAuthorViewModel model)
        {   
            var response = await _service.DeleteAsync(model);

            return Ok(response);
        }
    }
}
