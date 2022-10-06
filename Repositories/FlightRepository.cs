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


        public ResponseModel BookFlight(FlightBookingModel model)
        {
            ResponseModel responseModel = new ResponseModel();  
            var exist = _dbContext.Set<FlightBookingModel>().Where(t => t.Id == model.Id &&
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
                if (model.Trip_Type==Trip_type.OneWay)
                {
                    model.new_destination=null;
                    model.new_location=null;
                    
                }
                
                _dbContext.Add(model);
                _dbContext.SaveChanges();
            }
            return responseModel;
        }

        public ResponseModel CreateFlight(FlightModel model)
        {
           ResponseModel responseModel= new ResponseModel();
            var exist = _dbContext.Set<FlightModel>().Where(t => t.Id == model.Id &&
                                                                    t.FlightName== model.FlightName &&
                                                                    t.departure == model.departure &&
                                                                    t.destination == model.destination &&
                                                                    t.TakeOffTime == model.TakeOffTime &&
                                                                    t.Travel_date == model.Travel_date
                                                                    ).ToList();

            if (exist.Count>0)
            {
                responseModel.IsSuccessful= false;
                responseModel.Error="This flight already exists";
            }
            else
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
            }
            return responseModel;
        }

        public ResponseModel DeleteFlight(long Id)
        {
            ResponseModel responseModel = new ResponseModel();
           var flightExist = GetFlight(Id);
            if (flightExist != null)
            {
                //_dbContext.Remove(flightexists);
                flightExist.Isdeleted = true;
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

        public List<FlightBookingModel> GetAllBookings()
        {
            var flight = _dbContext.Set<FlightBookingModel>().ToList();
            return flight;
        }

        public FlightModel GetFlight(long Id)
        {
            var flight = _dbContext.Set<FlightModel>().FirstOrDefault(x => x.Id == Id);
            return flight;
            
        }

        public List<FlightModel> GetFlights()
        {
           var flight = _dbContext.Set<FlightModel>().Where(t=>t.Isdeleted==false).ToList();
            return flight;
        }

        public List<FlightModel> GetFlightsByDestination(string Destination)
        {
            var flight = _dbContext.Set<FlightModel>().Where(x => x.destination == Destination).ToList();
            return flight;
        }

        public ResponseModel UpdateFlight(FlightModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            var exist = _dbContext.Set<FlightModel>().Where(c => c.Id == model.Id).FirstOrDefault();
            if (exist != null)
            {
                _dbContext.Update(model);
                _dbContext.SaveChanges();
                responseModel.IsSuccessful=true;
            }
            else
            {
                responseModel.IsSuccessful=false;
                responseModel.Error="This flight does not exist";
            }

            return responseModel;
        }

    }
}
