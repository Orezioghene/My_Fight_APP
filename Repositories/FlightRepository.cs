using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using My_Fight_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Fight_APP.Repositories
{
    public class FlightRepository : IFllightInterface

    {
        private FlightDbContext _dbContext;
        private readonly IPaymentInterface _paymentrepo;
        private readonly IConfiguration _config;

        public FlightRepository(IConfiguration config, FlightDbContext dbContext, IPaymentInterface paymentrepo)
        {
            _config = config;
            _dbContext = dbContext;
            _paymentrepo = paymentrepo;
        }
      


        public async Task<ResponseModel>   BookFlight(FlightBookingViewModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            var linkid=_dbContext.Set<FlightModel>().Where(t => t.TripAmount == model.Amount);
            var exist = _dbContext.Set<FlightBookingModel>().Where(t => 
                                                                    t.Destination== model.Destination &&
                                                                    t.Location == model.Location &&
                                                                    t.flight_Categories == model.flight_Categories &&
                                                                    t.Flight_name ==model.Flight_name &&
                                                                    t.CreatedOn == model.CreatedOn).ToList()
                                                                    ;
            model.Amount= model.Amount * model.numberOfSeats;

            if (exist.Count>0)
            {
                responseModel.IsSuccessful= false;
                responseModel.Error="This Seat is already taken";
            }
            else
            {
                var rand = new Random();
                int randnum = rand.Next(1000);
                var tx_ref = $"Flight-{randnum}-{DateTime.Now}";
                var newUser = new FlightBookingModel()
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    email = model.email,
                    UserName = model.UserName,
                    Amount = model.Amount,
                    CreatedOn = DateTime.Now.Date,   
                    new_destination = model.Destination,
                    Destination = model.Destination,
                    Location = model.Location,
                    Flight_name = model.Flight_name,
                    
                    numberOfSeats = model.numberOfSeats,
                    PaymentStatus = model.PaymentStatus,
                    flight_Categories = model.flight_Categories,
                    new_location = model.Location,
                    Trip_Type = model.Trip_Type,    


                };
                var sendPayment = new PaymentRequestModel()
                {
                    amount = model.Amount,
                    currency = "NGN",
                    customer = new Customer()
                    {
                        email= model.email,
                        name = model.UserName,
                        phonenumber = model.PhoneNumber
                    },
                    redirect_url ="https://localhost:4002",
                    tx_ref = tx_ref
                };
                var request = await _paymentrepo.makepayment(sendPayment);

                if (model.Trip_Type==Trip_type.OneWay)
                {
                    model.new_destination=null;
                    model.new_location=null;
                    
                }
                
                _dbContext.Add(newUser);
                _dbContext.SaveChanges();
                responseModel.IsSuccessful=true;
                responseModel.Error= request.data.link;
            }
            return responseModel;
        }
        //[Authorize]
        public ResponseModel CreateFlight(FlightViewModel model)
        {
           ResponseModel responseModel= new ResponseModel();
            var exist = _dbContext.Set<FlightModel>().Where(t => 
                                                                    t.FlightName== model.FlightName &&
                                                                    t.departure == model.departure &&
                                                                    t.destination == model.destination &&
                                                                    t.TakeOffTime == model.TakeOffTime &&
                                                                    t.Travel_date == model.Travel_date
                                                                    ).ToList();
            var newFlight = new FlightModel()
            {
                FlightName = model.FlightName,
                departure = model.departure,
                destination = model.destination,
                TakeOffTime = model.TakeOffTime,
                Travel_date = model.Travel_date,
                AllowRoundTrip= model.AllowRoundTrip,
                Flight_duration= model.Flight_duration,
                TripAmount=model.TripAmount,



            };

            if (exist.Count>0)
            {
                responseModel.IsSuccessful= false;
                responseModel.Error="This flight already exists";
            }
            else
            {
                _dbContext.Add(newFlight);
                _dbContext.SaveChanges();
                responseModel.IsSuccessful= true;
                responseModel.Error="Flight Created";
            }
            return responseModel;
        }

        [Authorize]
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
        [Authorize]
        public FlightBookingModel GetBooking(string Username)
        {
            var flight = _dbContext.Set<FlightBookingModel>().FirstOrDefault(x => x.UserName == Username);
            return flight;
        }

        [Authorize]
        public List<FlightBookingModel> GetAllBookings()
        {
            var flight = _dbContext.Set<FlightBookingModel>().ToList();
            return flight;
        }

        public FlightModel GetFlight(long Id)
        {
            return _dbContext.Set<FlightModel>().FirstOrDefault(x => x.Id == Id);                       
        }

        public List<FlightModel> GetFlights()
        {
            return _dbContext.Set<FlightModel>().Where(t=>t.Isdeleted==false).ToList();            
        }

        public List<FlightModel> GetFlightsByDestination(string Destination)
        {
            var flight = _dbContext.Set<FlightModel>().Where(x => x.destination == Destination).ToList();
            return flight;
        }

        [Authorize]
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

        public ResponseModel CancelBooking(string Username)
        {

            ResponseModel responseModel = new ResponseModel();
            var flightExist = GetBooking(Username);
            if (flightExist != null)
            {
                //_dbContext.Remove(flightexists);
                flightExist.Isdeleted = true;
                _dbContext.SaveChanges();

                responseModel.IsSuccessful = true;
                responseModel.Error="Booking has been cancelled";
            }
            else
            {
                responseModel.IsSuccessful = false;
                responseModel.Error="This username doesn't exist under any booking";
            }

            return responseModel;
        }

        public ResponseModel CorrectBooking(FlightBookingModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            var exist = _dbContext.Set<FlightBookingModel>().Where(c => c.Id == model.Id).FirstOrDefault();
            if (exist != null)
            {
                _dbContext.Update(model);
                _dbContext.SaveChanges();
                responseModel.IsSuccessful=true;
            }
            else
            {
                responseModel.IsSuccessful=false;
                responseModel.Error="This booking does not exist";
            }

            return responseModel;
        }
    }
}
