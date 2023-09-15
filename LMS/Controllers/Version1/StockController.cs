using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Stock;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Version1
{
    [Route("api/v1/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;
        public StockController(IStockService service) => _service = service;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetStockDto>))]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAsync());

        [HttpGet("{bookId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetStockDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int bookId)
        {
            if (bookId <= 0) return BadRequest("Invalid book ID");

            var response = await _service.GetAsync(bookId);

            return response.ResponseData is null ? NotFound(response.Message) : Ok(response);
        }
    }
}
