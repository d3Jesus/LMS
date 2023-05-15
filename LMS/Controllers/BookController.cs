using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("getByCategory/{categoryId:int}")]
        public async Task<IActionResult> GetAll(int categoryId)
        {
            return Ok(await _service.GetAllByAsync(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookDto model)
        {
            var response = await _service.CreateAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetBookDto model)
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
