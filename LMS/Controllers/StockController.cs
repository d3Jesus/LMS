using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Stock;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;
        public StockController(IStockService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStockDto model)
        {
            var response = await _service.CreateAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetStockDto model)
        {
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }
    }
}
