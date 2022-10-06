using Microsoft.EntityFrameworkCore;
using My_Fight_APP.Models;

namespace My_Fight_APP
{
    public class FlightDbContext:DbContext
    {
        public FlightDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<FlightBookingModel> FlightBookings { get; set; }
        DbSet<FlightModel> FlightModel { get; set; }
        DbSet<PaymentModel> PaymentModels { get; set; }
       
       

    }
}
