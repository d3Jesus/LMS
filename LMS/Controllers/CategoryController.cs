using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Author;
using LMS.Application.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService categoryService)
        {
            _service = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDto model)
        {
            var response = await _service.CreateAsync(model);

            return Ok(response);
        }
    }
}
