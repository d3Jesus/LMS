using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;
        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddReservationDto model)
        {
            var response = await _service.CreateAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetReservationDto model)
        {
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }
    }
}
