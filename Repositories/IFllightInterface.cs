using My_Fight_APP.Models;
using System.Collections.Generic;

namespace My_Fight_APP.Repositories
{
    public interface IFllightInterface
    {
        public List<FlightModel> GetFlights();
        public FlightModel GetFlight(long Id);
        public List<FlightBookingModel> GetAllBookings();
        public List<FlightModel> GetFlightsByDestination(string Location);
        ResponseModel BookFlight( FlightBookingModel model);
        ResponseModel CreateFlight(FlightModel model );
        ResponseModel UpdateFlight( FlightModel model );
        ResponseModel DeleteFlight( long Id);
    }
}
