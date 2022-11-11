using System;

namespace My_Fight_APP.Models
{
    public class FlightBookingModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Flight_name { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Location { get; set; }
        public string Destination { get; set; }        
        public Flight_Categories flight_Categories { get; set; }
        public Trip_type Trip_Type { get; set; }
        public string new_destination { get; set; }
        public string new_location { get; set; }
        public int numberOfSeats { get; set; }
        public decimal Amount { get; set; }
        public bool Isdeleted { get; set; } = false;
        public string PaymentStatus { get; set; }

        public string email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }

    }

    public enum Trip_type
    {
        OneWay,
        RoundTrip
    }

  

    public enum Flight_Categories
    {
        Business,
        Economy,
        FirstClass
        
    }


}
