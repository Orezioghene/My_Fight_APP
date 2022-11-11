using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using My_Fight_APP.Models;

namespace My_Fight_APP
{
    public class FlightDbContext:IdentityDbContext<User>
    {
        public FlightDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        DbSet<FlightBookingModel> FlightBookings { get; set; }
        DbSet<FlightModel> FlightModel { get; set; }
       

        public class FlightDbContextFactory : IDesignTimeDbContextFactory<FlightDbContext>
        {
            public FlightDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<FlightDbContext>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-QIH8BPF;Database=myflightapp;MultipleActiveResultSets=True;Trusted_Connection=True");

                return new FlightDbContext(optionsBuilder.Options);
            }
        }



    }
}
