using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Librarian;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/librarians")]
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianService _service;
        public LibrarianController(ILibrarianService service)
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

        [HttpPost]
        public async Task<IActionResult> Add(AddLibrarianDto model)
        {
            var response = await _service.CreateAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetLibrarianDto model)
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
