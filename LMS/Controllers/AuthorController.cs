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
            return Ok(await _service.GetAsync(false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByAsync(id));
        }

        [HttpGet("getByName/{name:alpha}")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await _service.GetByAsync(name));
        }

        [HttpGet("{nationality}")]
        public async Task<IActionResult> GetByNationality(string nationality)
        {
            return Ok(await _service.GetByNationalityAsync(nationality));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAuthorDto model)
        {   
            var response = await _service.CreateAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetAuthorDto model)
        {   
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest(id);

            var response = await _service.DeleteAsync(id);

            return Ok(response);
        }
    }
}
