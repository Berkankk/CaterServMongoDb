using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.AboutDtos;

namespace CaterServMongoDb.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<UpdateAboutDto, ResultAboutDto>().ReverseMap();
        }
    }
}
