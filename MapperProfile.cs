using AutoMapper;
using Webia.Entities;
using Webia.Models;

namespace Webia.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Flight, FlightModel>()
                .ForMember(dest => dest.ArivalCity, opt => opt.MapFrom(src => src.ArivalCity))
                .ReverseMap();

            CreateMap<Reservation, ReservationModel>()
                .ForMember(dest => dest.PassengerName, opt => opt.MapFrom(src => src.PassengerName))
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ReverseMap();
        }
    }
}
