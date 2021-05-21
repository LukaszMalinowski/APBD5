using System;
using cwiczenia5_zen_s19743.Exceptions;
using cwiczenia5_zen_s19743.Services;
using Microsoft.AspNetCore.Mvc;

namespace cwiczenia5_zen_s19743.Controllers
{
    [Route("/api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [Route("{idClient}")]
        [HttpDelete]
        public IActionResult DeleteClient(int idClient)
        {
            try
            {
                _service.DeleteClient(idClient);
            }
            catch (ClientNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ClientHasTripsException e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }
    }
}