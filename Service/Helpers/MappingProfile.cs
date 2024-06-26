using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
using Service.DTOs.Cities;
using Service.DTOs.Countries;


namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryEditDto, Country>();
            CreateMap<Country, CountryDetailDto>();

            CreateMap<City, CityDto>().ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<CityCreateDto, City>();
            CreateMap<CityEditDto, City>();
            CreateMap<City, CityDetailDto>().ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
        }
    }
}
