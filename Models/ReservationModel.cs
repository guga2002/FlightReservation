namespace Webia.Models
{
    public class ReservationModel
    {
        public string PassengerName { get; set; }

        public Guid FlightId { get; set; }

        public override string ToString()
        {
            return $"PassengerName{PassengerName} FlightId {FlightId};";
        }
    }
}
