using Microsoft.EntityFrameworkCore;
using My_Fight_APP.Models;

namespace My_Fight_APP
{
    public class FlightDbContext:DbContext
    {
        public FlightDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Flight_Models> Flight_Models { get; set; }
        DbSet<One_way_Ticket> One_Way_Tickets { get; set; }
        DbSet<Round_ticket> round_Tickets { get; set; }
        DbSet<FlightModelOneWay> One_way_flight_model { get; set; }
        DbSet<FlightModelRoundTicket> Round_Ticket_Flight_model { get; set; }

    }
}
