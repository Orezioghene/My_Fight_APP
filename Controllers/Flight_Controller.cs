using Microsoft.AspNetCore.Mvc;
using My_Fight_APP.Models;
using My_Fight_APP.Repositories;
using System.Threading.Tasks;

namespace My_Fight_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("GetFlightbyId/{Id}")]
        public IActionResult GetFlight(long Id)
        {
            var flight = _flightinterface.GetFlight(Id);
            if (flight == null)
            {
                return NotFound();

            }
            return Ok(flight);
        }
        [HttpGet("GetBooking/{Username}")]
        public IActionResult GetBooking(string Username)
        {
            var booking = _flightinterface.GetBooking(Username);
            if(booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpGet("AllBookings")]
        public IActionResult GetBookings()
        {
            var bookings = _flightinterface.GetAllBookings();
            if (bookings == null) { return NotFound(); }
            return Ok(bookings);
        }

        [HttpGet("FlightByDestination/{destination}")]
        public IActionResult FlightByLocation(string destination)
        {
            var flightbylocation = _flightinterface.GetFlightsByDestination(destination);
            if (flightbylocation == null) { return NotFound(); }
            return Ok(flightbylocation);
        }

        [HttpPost("BookFlight")]
        public async Task<IActionResult> BookFlight(FlightBookingViewModel bookingModel)
        {
            var bookflight = await  _flightinterface.BookFlight(bookingModel);
            if (bookflight.IsSuccessful==true)
            {
                return Ok(bookflight);
            }
            return BadRequest();
        }

        [HttpPost("CreateFlight")]
        public IActionResult CreateFlight(FlightViewModel createflightmodel)
        {
            if (!ModelState.IsValid) { return BadRequest("Ensure right pattern and datatype is followed"); };
            var createflight = _flightinterface.CreateFlight(createflightmodel);
            if (createflight.IsSuccessful==true)
            {
                return Ok(createflight);
            }
            return BadRequest();
        }
        [HttpDelete("deleteflight/Id")]
        public IActionResult DeleteFlight(long Id)
        {
            var delete = _flightinterface.DeleteFlight(Id);
            return Ok(delete);

        }

        [HttpDelete("CancelBooking")]
        public IActionResult CancelFlight(string Username)
        {
            var delete = _flightinterface.CancelBooking(Username);
            return Ok(delete);

        }

        [HttpPut("correctbooking/{Id}")]
        public IActionResult CorrectBooking(long Id , FlightBookingModel bookingModel)
        {
            var exists = _flightinterface.GetFlight(Id);
            if (exists == null)
            {
                return NotFound();

            }
            else
            {
                bookingModel.Id=exists.Id;
                var correctbooking = _flightinterface.CorrectBooking(bookingModel);
                return Ok(correctbooking);
            }
           
        }

        [HttpPut("updateflight/{id}")]
        public IActionResult UpdateFlight(long Id, FlightModel flight)
        {
            var exists = _flightinterface.GetFlight(Id);
            if(exists ==null)
            {
                return NotFound();
            }
            else
            {
                flight.Id=exists.Id;
                var updateflight = _flightinterface.UpdateFlight(flight);
                return Ok(updateflight);
                
            }
        }




    }
}
