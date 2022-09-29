using My_Fight_APP.Models;
using System.Collections.Generic;

namespace My_Fight_APP.Repositories
{
    public interface IFllightInterface
    {
        public List<Flight_Models> GetFlights();
        public Flight_Models GetFlight(long Id);
        ResponseModel BookFlight( Flight_Models model);
        ResponseModel CreateFlight(Flight_Models model );
        ResponseModel UpdateFlight( Flight_Models model );
        ResponseModel DeleteFlight( long Id);
    }
}
