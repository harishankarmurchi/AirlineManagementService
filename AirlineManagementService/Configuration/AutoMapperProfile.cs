using AutoMapper;
using Models.DBModels;
using Models.ViewModels;

namespace AirlineManagementService.Configuration
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Place, PlaceVm>()
                .ForMember(dest => dest.PlaceId,opt => opt.MapFrom(src=> src.Id))
                .ForMember(dest => dest.PlaceName, opt => opt.MapFrom(src => src.PlaceName))
                .ReverseMap();
            CreateMap<MealType, MealVm>()
                .ForMember(dest => dest.MealId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MealType, opt => opt.MapFrom(src => src.Type))
                .ReverseMap();

           

            CreateMap<SeatVM, FlightSeats>().ReverseMap();
            CreateMap<AirlineVM, Airline>().ReverseMap();

            CreateMap<FlightVM, Flight>()
                .ForMember(dest => dest.ShedhuleDays, opt => opt.MapFrom(src => String.Join(",", src.ShedhuleDays)));

            CreateMap<Flight, FlightVM>()

                .ForMember(dest => dest.ShedhuleDays, opt => opt.MapFrom(src => MapSheduleDays(src.ShedhuleDays)))

                .ForMember(dest => dest.FromPlaceName, opt => opt.MapFrom(src => src.FromPlace.PlaceName))
                .ForMember(dest => dest.ToPlaceName, opt => opt.MapFrom(src => src.ToPlace.PlaceName))
                .ForMember(dest => dest.MealTypeName, opt => opt.MapFrom(src => src.MealType.Type))
                .ForMember(dest => dest.NonBusinessClassSeats, opt => opt.MapFrom(src => src.NonBusinessClasssSeats))
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.Id));
               











        }
        static List<string>MapSheduleDays(string days)
        {
            return days.Split(",").ToList();
        }
    }
}
