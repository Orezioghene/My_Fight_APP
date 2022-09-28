namespace My_Fight_APP.Models
{
    public class FlightModelRoundTicket
    {
        public int FlightModelId { get; set; }
        public int Id { get; set; }
        public Flight_Models Flight_Models { get; set; }
        public Round_ticket RoundTicket { get; set; }
    }
}
