namespace My_Fight_APP.Models
{
    public class FlightModel
    {
        public int Id { get; set; }
        public string FlightName { get; set; }
        public string departure { get; set; }
        public string destination { get; set; }
        public bool AllowRoundTrip { get; set; }
        public decimal TripAmount { get; set; }
        public string Travel_date { get; set; }
        public string TakeOffTime { get; set; }
        public string Flight_duration { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
