using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Reader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/readers")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderService _service;
        public ReaderController(IReaderService service)
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
        public async Task<IActionResult> Add(AddReaderViewModel model)
        {
            var response = await _service.AddAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetReaderViewModel model)
        {
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest(id);

            var reader = await _service.GetByIdAsync(id);

            if (reader.ResponseData is null)
                return NotFound();

            var response = await _service.DeleteAsync(reader.ResponseData);

            return Ok(response);
        }
    }
}
