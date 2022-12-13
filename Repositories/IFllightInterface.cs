using My_Fight_APP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My_Fight_APP.Repositories
{
    public interface IFllightInterface
    {
        public List<FlightModel> GetFlights();
        public FlightModel GetFlight(long Id);
        public FlightBookingModel GetBooking(string Username);
        public List<FlightBookingModel> GetAllBookings();
        public List<FlightModel> GetFlightsByDestination(string Location);
        Task<ResponseModel> BookFlight( FlightBookingViewModel model);
        ResponseModel CorrectBooking ( FlightBookingModel model);
        ResponseModel CreateFlight(FlightViewModel model );
        ResponseModel UpdateFlight( FlightModel model );
        ResponseModel DeleteFlight( long Id);
        ResponseModel CancelBooking(string Username);


    }
}
