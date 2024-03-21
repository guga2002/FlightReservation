using Microsoft.EntityFrameworkCore;
using Webia.Data;
using Webia.Entities;
using Webia.Interface;

namespace Webia.Repositories
{
    public class FlightReservationRepository : AbstractRepos,IFlightReservationSystem
    {
        private readonly ILogger<FlightReservationRepository> logger;

        private  readonly DbSet<Reservation> reservations;
        private readonly DbSet<Flight> flights;
        public FlightReservationRepository(FlightContext conte, ILogger<FlightReservationRepository> logger) : base(conte)
        {
            reservations = this.context.Set<Reservation>();
            flights = this.context.Set<Flight>();
            this.logger = logger;
        }

        public void Add(Flight entity)
        {
            flights.Add(entity);
            context.SaveChanges();
            logger.LogInformation("Warmatebit daemata frena");
        }

        public void Add(Reservation entity)
        {
            var flight= flights.Where(io => io.Id == entity.FlightId).FirstOrDefault();
            if  (flight!=null&& flight.AvalibleSeats >= 0)
            {
                reservations.Add(entity);
                logger.LogInformation("Warmatebit daemata Reservation");
                flight.AvalibleSeats++;
                context.SaveChanges();
            }
        }

        public bool BookTicket(Guid Id, string passengerName)
        {
            try
            {
                var flight = flights.Where(io => io.Id ==Id).FirstOrDefault();
                if (flight != null && flight.AvalibleSeats >= 0)
                {
                    reservations.Add(new Reservation { FlightId = Id, PassengerName = passengerName });
                    logger.LogInformation("BookTicket Success");
                    flight.AvalibleSeats++;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception exp)
            {
                logger.LogError(exp.StackTrace);
                logger.LogCritical(exp.Message);
                return false;
            }
        }

        public bool CancelReservation(Guid reservation)
        {
            try
            {

                if (reservations.Any(io => io.Id == reservation))
                {
                    var frs = reservations.FirstOrDefault(io => io.Id == reservation);
                    if (frs == null) return false;
                    frs.flight.AvalibleSeats--;
                    reservations.Remove(frs);
                    context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception exp )
            {
                logger.LogError(exp.StackTrace);
                logger.LogCritical(exp.Message);
                return false;
            }
        }

        public IEnumerable<Flight> SearchFlights(string departureCity, string arrivalCity, DateTime departureDate)
        {
           var res= flights.Where(io => io.DepartureCity == departureCity && io.ArivalCity == arrivalCity && io.DepartureTime == departureDate)
                .Include(io=>io.Reservations).ToList();
            logger.LogInformation("moidzebna frena");
            return res;

        }

        public void Update(Flight entity)
        {
            if (flights.Any(io => io.Id == entity.Id))
            {
                flights.Update(entity);
                context.SaveChanges();
            }
            logger.LogInformation($"ganaxlda frena {entity}");
        }

        public void Update(Reservation entity)
        {
           if(reservations.Any(io=>io.Id==entity.Id))
            {
                reservations.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
