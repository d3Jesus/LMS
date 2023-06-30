using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Purchase;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/purchases")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _service;
        public PurchaseController(IPurchaseService service)
        {
            _service = service;
        }

        [HttpGet("{initDate}/{endDate}")]
        public async Task<IActionResult> GetAll(DateTime initDate, DateTime endDate)
        {
            return Ok(await _service.GetAsync(initDate, endDate));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPurchaseDto model)
        {
            var response = await _service.AddAsync(model);

            return Ok(response);
        }
    }
}
