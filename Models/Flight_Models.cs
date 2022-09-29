using System;

namespace My_Fight_APP.Models
{
    public class Flight_Models
    {
        public int Id { get; set; }
        public string Flight_name { get; set; }
        public DateTime CreatedOn { get; set; }
        public Destination Location { get; set; }
        public Destination Destination { get; set; }
        public string Travel_date { get; set; }
        public string TakeOffTime { get; set; }
        public string Flight_duration { get; set; }
        public One_way_Ticket One_Way_Tickets { get; set; }
        public Round_ticket Round_Tickets { get; set; }
        public Flight_Categories flight_Categories { get; set; }

       
    }

    public enum Destination
    { 
        Lagos,
        Abuja,
        Port_Harcourt
    }

    public enum Flight_Categories
    {
        Business,
        Economy,
        FirstClass
        
    }


}
