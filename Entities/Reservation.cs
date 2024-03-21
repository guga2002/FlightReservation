using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webia.Entities
{
    [Table("Reservations")]
    [Index(nameof(PassengerName)]
    public class Reservation:AbstractEntity
    {
        [Column("Full_Name")]
        [Required]
        public string PassengerName { get; set; }

        [ForeignKey("flight")]
        public Guid FlightId { get; set; }
        public Flight flight { get; set; }
    }
}
