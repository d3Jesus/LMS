using LMS.Application.Interfaces;
using LMS.Application.ViewModels.PublishingCompany;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/publishing-companies")]
    [ApiController]
    public class PublishingCompanyController : ControllerBase
    {
        private readonly IPublishingCompanyService _service;
        public PublishingCompanyController(IPublishingCompanyService service)
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
        public async Task<IActionResult> Add(AddPublishingCompanyViewModel model)
        {
            var response = await _service.AddAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetPublishingCompanyViewModel model)
        {
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest(id);

            var pCompany = await _service.GetByIdAsync(id);

            if (pCompany.ResponseData is null)
                return NotFound();

            var response = await _service.DeleteAsync(pCompany.ResponseData);

            return Ok(response);
        }
    }
}
