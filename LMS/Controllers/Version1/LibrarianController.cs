using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Librarian;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Version1
{
    [Route("api/v1/librarians")]
    [ApiController]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianService _service;
        public LibrarianController(ILibrarianService service) => _service = service;

        [HttpGet("currentPage={currentPage}&pageSize={pageSize}/{searchTerm?}/{sortColumn?}/{sortOrder?}/{wasDeleted?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<GetLibrarianDto>))]
        public async Task<IActionResult> Get(int currentPage, int pageSize, string? searchTerm = "", string? sortColumn = "id", string? sortOrder = "desc", bool wasDeleted = false)
        {
            ResourceRequest request = new(currentPage, pageSize, searchTerm, sortColumn, sortOrder, wasDeleted);
            return Ok(await _service.GetAsync(request));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLibrarianDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest("Invalid librarian identifier.");

            var response = await _service.GetByAsync(id);

            return response.ResponseData is null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetLibrarianDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddLibrarianDto librarianDto)
        {
            if (librarianDto == null) return BadRequest("Provide the required librarian information.");

            var response = await _service.CreateAsync(librarianDto);

            return response.ResponseData is not null ? CreatedAtAction(nameof(Get), new { response.ResponseData.Id }) : BadRequest(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLibrarianDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateLibrarianDto librarianDto)
        {
            if (librarianDto == null) return BadRequest("Provide the required librarian information.");

            var response = await _service.UpdateAsync(librarianDto);

            return response.ResponseData is not null ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest(id);

            var response = await _service.DeleteAsync(id);

            return response.ResponseData ? NoContent() : BadRequest(response);
        }
    }
}
