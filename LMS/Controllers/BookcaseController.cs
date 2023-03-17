using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Bookcase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/bookcases")]
    [ApiController]
    public class BookcaseController : ControllerBase
    {
        private readonly IBookcaseService _service;
        public BookcaseController(IBookcaseService service)
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

        [HttpPost]
        public async Task<IActionResult> Add(AddBookcaseViewModel model)
        {
            var response = await _service.AddAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetBookcaseViewModel model)
        {
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(id);

            var response = await _service.DeleteAsync(id);

            return Ok(response);
        }
    }
}
