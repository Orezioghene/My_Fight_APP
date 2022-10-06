using Microsoft.AspNetCore.Mvc;
using My_Fight_APP.Models;
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

        [HttpGet("GetAllflights")]
        public IActionResult GetAllFlights()
        {
            var flights = _flightinterface.GetFlights();
            if (flights == null)
            {
                return NotFound();
            };
            return Ok(flights);

        }

        [HttpGet("{Id}")]
        public IActionResult GetFlight(long Id)
        {
            var flight = _flightinterface.GetFlight(Id);
            if (flight == null)
            {
                return NotFound();

            }
            return Ok(flight);
        }

        [HttpGet("AllBookings")]
        public IActionResult GetBookings()
        {
            var bookings = _flightinterface.GetAllBookings();
            if(bookings == null) { return NotFound(); }
            return Ok(bookings);
        }

        [HttpGet("{destination}")]
        public IActionResult FlightByLocation(string Location)
        {
            var flightbylocation = _flightinterface.GetFlightsByDestination(Location);
            if(flightbylocation == null) { return NotFound(); }
            return Ok(flightbylocation);
        }

        [HttpPost("BookFlight")]
        public IActionResult BookFlight(FlightBookingModel bookingModel )
        {
            var bookflight = _flightinterface.BookFlight(bookingModel);
            if (bookflight.IsSuccessful==true)
            {
                return Ok(bookflight);
            }
            return BadRequest();
        }

        [HttpPost("CreateFlight")]
        public IActionResult CreateFlight(FlightModel createflightmodel)
        {
            if (!ModelState.IsValid) { return BadRequest("Ensure right pattern and datatype is followed");} ;
            var createflight = _flightinterface.CreateFlight(createflightmodel);
            if (createflight.IsSuccessful==true)
            {
                return Ok(createflight);
            }
            return BadRequest();
        }
        [HttpDelete("Id")]
        public IActionResult DeleteFlight(long Id)
        {
            var delete = _flightinterface.DeleteFlight(Id);
            return Ok(delete);

        }

        
    }
}
