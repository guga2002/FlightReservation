using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webia.Entities
{
    [Table("Flights")]
    [Index(nameof(DepartureCity))]
    [Index(nameof(ArivalCity))]
    public class Flight:AbstractEntity
    {

        [Column("Departure_city")]
        [Required]
        public string DepartureCity { get; set; }

        [Column("Destination")]
        [Required]
        public string ArivalCity { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        public int AvalibleSeats { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
