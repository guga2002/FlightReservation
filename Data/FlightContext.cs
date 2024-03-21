using Microsoft.EntityFrameworkCore;
using Webia.Entities;

namespace Webia.Data
{
    public class FlightContext:DbContext
    {
        public FlightContext(DbContextOptions<FlightContext>ops):base(ops)
        {
                
        }

        public virtual DbSet<Flight> FLights { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}
