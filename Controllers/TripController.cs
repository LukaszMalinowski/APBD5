using System;
using cwiczenia5_zen_s19743.Exceptions;
using cwiczenia5_zen_s19743.Models.DTOs;
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
            return Ok(_service.GetAllTrips());
        }

        [Route("{idTrip}/clients")]
        [HttpPost]
        public IActionResult RegisterClientOnTrip(int idTrip, [FromBody] TripRegistrationDto registration)
        {
            registration.IdTrip = idTrip;
            
            try
            {
                _service.RegisterClientOnTrip(registration);
            }
            catch (TripException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}