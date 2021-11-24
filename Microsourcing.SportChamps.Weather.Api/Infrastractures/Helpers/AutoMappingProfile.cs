using AutoMapper;
using Microsourcing.SportChamps.Weather.Model.Weather;
using System;

namespace Microsourcing.SportChamps.Weather.Api.Infrastractures.Helpers
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Daily, DailyDTO>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.dt))
                .ForMember(dest => dest.Sunrise, opt => opt.MapFrom(src => src.sunrise))
                .ForMember(dest => dest.Sunset, opt => opt.MapFrom(src => src.sunset))
                .ForMember(dest => dest.MoonRise, opt => opt.MapFrom(src => src.moonrise))
                .ForMember(dest => dest.MoonSet, opt => opt.MapFrom(src => src.moonset))
                .ForMember(dest => dest.Moon_Phase, opt => opt.MapFrom(src => src.moon_phase));
        }
    }
}
