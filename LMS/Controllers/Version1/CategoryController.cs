using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Category;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Version1
{
    [ApiController]
    [Route("api/v1/categories")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService categoryService) => _service = categoryService;

        [HttpGet("currentPage={currentPage}&pageSize={pageSize}/{searchTerm?}/{sortColumn?}/{sortOrder?}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<GetCategoryResponse>))]
        public async Task<IActionResult> Get(int currentPage, int pageSize, string? searchTerm = "", string? sortColumn = "id", string? sortOrder = "desc")
        {
            ResourceRequest request = new(currentPage, pageSize, searchTerm, sortColumn, sortOrder);
            return Ok(await _service.GetAsync(request));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetCategoryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddCategoryDto model)
        {
            if (model == null) return BadRequest();

            var response = await _service.CreateAsync(model);

            return CreatedAtAction(nameof(Get), new { response.ResponseData.id }, response.ResponseData);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();

            var response = await _service.GetByAsync(id);

            return response.ResponseData is null ? NotFound() : Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCategoryDto model)
        {
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }

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
