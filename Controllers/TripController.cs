using cwiczenia5_zen_s19743.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia5_zen_s19743.Controllers
{
    [Route("api/trips")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _service;

        public TripController(ITripService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllTrips()
        {
            return Ok();
        }
    }
}