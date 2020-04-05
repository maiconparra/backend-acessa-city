using AcessaCity.API.Dtos;
using AcessaCity.API.Dtos.CityHall;
using AcessaCity.Business.Models;
using AutoMapper;
namespace AcessaCity.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.ParentCategory));

            CreateMap<CityHall, CityHallInsertDto>().ReverseMap();
            CreateMap<CityHall, CityHallDto>();
        }        
    }
}