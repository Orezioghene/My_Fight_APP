using My_Fight_APP.Models;
using System.Collections.Generic;
using System.Linq;

namespace My_Fight_APP.Repositories
{
    public class FlightRepository : IFllightInterface

    {
        private FlightDbContext _dbContext;
        public FlightRepository(FlightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseModel BookFlight(Flight_Models model)
        {
            ResponseModel responseModel = new ResponseModel();  
            var exist = _dbContext.Set<Flight_Models>().Where(t => t.Id == model.Id &&
                                                                    t.Destination== model.Destination &&
                                                                    t.Location == model.Location &&
                                                                    t.flight_Categories == model.flight_Categories &&
                                                                    t.Flight_name ==model.Flight_name).ToList();

            if (exist.Count>0)
            {
                responseModel.IsSuccessful= false;
                responseModel.Error="This Seat is already taken";
            }
            else
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
            }
            return responseModel;
        }

        public ResponseModel CreateFlight(Flight_Models model)
        {
            throw new System.NotImplementedException();
        }

        public ResponseModel DeleteFlight(long Id)
        {
            ResponseModel responseModel = new ResponseModel();
           var flightExist = GetFlight(Id);
            if (flightExist != null)
            {
                _dbContext.Remove(flightExist);
                _dbContext.SaveChanges();

                responseModel.IsSuccessful = true;
                responseModel.Error="Flight has been deleted";
            }
            else
            {
                responseModel.IsSuccessful = false;
                responseModel.Error="Flight doesn't exist";
            }

            return responseModel;
            
        }

        public Flight_Models GetFlight(long Id)
        {
            var flight = _dbContext.Set<Flight_Models>().FirstOrDefault(x => x.Id == Id);
            return flight;
            
        }

        public List<Flight_Models> GetFlights()
        {
           var flight = _dbContext.Set<Flight_Models>().ToList();
            return flight;
        }

        public ResponseModel UpdateFlight(Flight_Models model)
        {
            throw new System.NotImplementedException();
        }

    }
}
