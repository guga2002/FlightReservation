using Webia.Entities;

namespace Webia.Interface
{
    public interface IFlightReservationSystem:Ictud<Flight>,Ictud<Reservation>
    {
        IEnumerable<Flight> SearchFlights(string departureCity, string arrivalCity, DateTime departureDate);
        bool BookTicket(Guid Id, string passengerName);
        bool CancelReservation(Guid reservation);
    }
}
