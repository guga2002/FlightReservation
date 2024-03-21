using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webia.Entities;
using Webia.Interface;
using Webia.Models;

namespace Webia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightReservationController : ControllerBase
    {

        private readonly IFlightReservationSystem res;
        private readonly IMapper mapper;

        public FlightReservationController(IFlightReservationSystem res,IMapper map)
        {
            this.res = res;
            this.mapper = map;
        }

        [HttpPost]
        public IActionResult Add([FromBody]FlightModel entity)
        {
            try
            {
               var mapped=mapper.Map<Flight>(entity);
                res.Add(mapped);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("Reservation")]
        public IActionResult Add([FromBody] ReservationModel entity)
        {
            try
            {
                var mapped = mapper.Map<Reservation>(entity);
                res.Add(mapped);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{Id}")]
        public IActionResult BookTicket(Guid Id, string passengerName)
        {
            try
            {

                res.BookTicket(Id, passengerName);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{reservation}")]
        public IActionResult CancelReservation(Guid reservation)
        {
            res.CancelReservation(reservation);
            return Ok();
        }

        [HttpGet("{departureCity}")]
        public IActionResult SearchFlights(string departureCity, string arrivalCity, DateTime departureDate)
        {
            try
            {

                var re = res.SearchFlights(departureCity, arrivalCity, departureDate);
                if (re == null)
                {
                    return NotFound();
                }
                var mapped = mapper.Map<IEnumerable<FlightModel>>(re);
                return Ok(re);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPut("Flight")]
        public IActionResult Update([FromBody] FlightModel entity)
        {
            try
            {
                var mapped = mapper.Map<Flight>(entity);
                res.Update(mapped);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Reservation")]
        public IActionResult Update([FromBody]ReservationModel entity)
        {
            try
            {
                var mapped = mapper.Map<Reservation>(entity);
                res.Update(mapped);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
