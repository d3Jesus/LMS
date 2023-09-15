using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Author;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Version1
{
    [ApiController]
    [Route("api/v1/authors")]
    [Authorize(Roles = "Admin")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service) => _service = service;

        [HttpGet("currentPage={currentPage}&pageSize={pageSize}&sortColumn={sortColumn}&sortOrder={sortOrder}&deleted={wasDeleted}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<GetAuthorsResponse>))]
        public async Task<IActionResult> Get(int currentPage, int pageSize, string sortColumn, string sortOrder, bool wasDeleted)
        {
            GetAuthorsRequest request = new(currentPage, pageSize, sortColumn, sortOrder, wasDeleted);
            return Ok(await _service.GetAsync(request));
        }

        [HttpGet("currentPage={currentPage}&pageSize={pageSize}&sortColumn={sortColumn}&sortOrder={sortOrder}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<GetAuthorsResponse>))]
        public async Task<IActionResult> Get(int currentPage, int pageSize, string sortColumn, string sortOrder)
        {
            GetAuthorsRequest request = new(currentPage, pageSize, sortColumn, sortOrder);
            return Ok(await _service.GetAsync(request));
        }

        [HttpGet("currentPage={currentPage}&pageSize={pageSize}&sortColumn={sortColumn}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<GetAuthorsResponse>))]
        public async Task<IActionResult> Get(int currentPage, int pageSize, string sortColumn)
        {
            GetAuthorsRequest request = new(currentPage, pageSize, sortColumn);
            return Ok(await _service.GetAsync(request));
        }

        [HttpGet("currentPage={currentPage}&pageSize={pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<GetAuthorsResponse>))]
        public async Task<IActionResult> Get(int currentPage, int pageSize)
        {
            GetAuthorsRequest request = new(currentPage, pageSize);
            return Ok(await _service.GetAsync(request));
        }

        /// <summary>
        /// Get author by the given ID
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAuthorDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();

            var response = await _service.GetByAsync(id);

            return response.ResponseData is null ? NotFound() : Ok(response);
        }

        /// <summary>
        /// Retrieve authors with the given name.
        /// </summary>
        /// <param name="name">Author name.</param>
        /// <returns></returns>
        [HttpGet("getByName/{name:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAuthorDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByName(string name)
        {
            var response = await _service.GetByAsync(name);

            return response.ResponseData is null ? NotFound() : Ok(response);
        }

        /// <summary>
        /// Retrieve authors with given nationality.
        /// </summary>
        /// <param name="nationality"></param>
        /// <returns></returns>
        [HttpGet("{nationality}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAuthorDto>))]
        public async Task<IActionResult> GetByNationality(string nationality) 
            => Ok(await _service.GetByNationalityAsync(nationality));

        /// <summary>
        /// Create a new author
        /// </summary>
        /// <param name="model">Author information</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetAuthorDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddAuthorDto model)
        {
            if (model == null) return BadRequest();

            var response = await _service.CreateAsync(model);

            return CreatedAtAction(nameof(Get), new { response.ResponseData.id }, response.ResponseData);
        }

        /// <summary>
        /// Update authors info.
        /// </summary>
        /// <param name="model">Author data</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdateAuthorDto model)
        {
            if (model == null) return BadRequest();

            return Ok(await _service.UpdateAsync(model));
        }

        /// <summary>
        /// Delete author with given ID
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var response = await _service.DeleteAsync(id);

            return response.ResponseData ? NoContent() : NotFound();
        }
    }
}
