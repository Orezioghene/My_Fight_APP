using Microsoft.AspNetCore.Mvc;
using My_Fight_APP.Repositories;

namespace My_Fight_APP.Controllers
{
    public class Flight_Controller : ControllerBase
    {
        private readonly IFllightInterface _flightinterface;
        public Flight_Controller(IFllightInterface fllightInterface)
        {
            _flightinterface = fllightInterface;
        }

        [HttpGet("flights")]
        public IActionResult GetAllFlights()
        {
            var flights = _flightinterface.GetFlights();
            if (flights == null)
            {
                return NotFound();
            };
            return Ok(flights);

        }

        
    }
}
