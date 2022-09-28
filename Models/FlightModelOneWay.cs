namespace My_Fight_APP.Models
{
    public class FlightModelOneWay
    {
        public int Id { get; set; }
        public int OneWayTicketId { get; set; }
        public Flight_Models Flight_ { get; set; }
        public One_way_Ticket OneWay { get; set; }
    }
}
