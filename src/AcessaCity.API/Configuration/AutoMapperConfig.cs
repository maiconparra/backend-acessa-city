using AcessaCity.API.Dtos;
using AcessaCity.API.Dtos.CityHall;
using AcessaCity.API.Dtos.Report;
using AcessaCity.API.Dtos.ReportAttachment;
using AcessaCity.API.Dtos.ReportCommentary;
using AcessaCity.API.Dtos.ReportStatus;
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
            CreateMap<ReportStatus, ReportStatusDto>();
            CreateMap<Report, ReportInsertDto>().ReverseMap();

            CreateMap<ReportCommentary, ReportCommentaryInsertDto>().ReverseMap();
            CreateMap<ReportAttachment, ReportAttachmentInsertDto>().ReverseMap();
        }
    }
}