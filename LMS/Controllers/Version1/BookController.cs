using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Version1
{
    [ApiController]
    [Route("api/v1/books")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IAuthorshipService _authorshipService;
        public BookController(IBookService service, IAuthorshipService authorshipService)
        {
            _service = service;
            _authorshipService = authorshipService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetBookDto>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(int id)
        {
            if (id <= 0) return BadRequest();

            var response = await _service.GetByIdAsync(id);

            return response.ResponseData is null ? NotFound() : Ok(response);
        }

        [HttpGet("category/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetBookDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int categoryId)
        {
            if (categoryId <= 0) return BadRequest();

            var response = await _service.GetAsync(categoryId);

            return response.ResponseData is null ? NotFound() : Ok(response);
        }

        [HttpGet("title/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetBookDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string title)
        {
            var response = await _service.GetAsync(title);

            return response.ResponseData is null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddBookDto model)
        {
            if (model is null) return BadRequest();

            var response = await _service.CreateAsync(model);

            return CreatedAtAction(nameof(Get), new { response.ResponseData.Id }, response.ResponseData);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateBookDto model)
        {
            if (model is null) return BadRequest();

            return Ok(await _service.UpdateAsync(model));
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest(id);

            var response = await _service.DeleteAsync(id);

            return response.ResponseData ? NoContent() : NotFound();
        }

        [HttpPost("authorship/{bookId:int}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetBookDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Authorship(int bookId, [FromBody] List<int> bookAuthors)
        {
            if (bookId <= 0) return BadRequest("Invalid book Id.");
            if (!bookAuthors.Any()) return BadRequest("The list of authors can't be empty.");

            var book = await _service.GetAsync(bookId);
            if (book == null) return NotFound($"Book with ID {bookId} not found.");

            var response = await _authorshipService.CreateOrUpdateAsync(bookId, bookAuthors);

            return response.ResponseData ? CreatedAtAction(nameof(Get), new { bookId }, null) : BadRequest(response.Message);
        }
    }
}
