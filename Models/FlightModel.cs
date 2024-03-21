
namespace Webia.Models
{
    public class FlightModel
    {
        public string DepartureCity { get; set; }

        public string ArivalCity { get; set; }

        public DateTime DepartureTime { get; set; }

        public int AvalibleSeats { get; set; }

        public override string ToString()
        {
            return $"DepartureCity:{DepartureCity} ArivalCity{ArivalCity} DepartureTime:{DepartureTime}; AvalibleSeatsL{AvalibleSeats} ";
        }
    }
}
