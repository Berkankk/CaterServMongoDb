using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.CheffDtos;

namespace CaterServMongoDb.Mapping
{
    public class CheffMapping : Profile
    {
        public CheffMapping()
        {
            CreateMap<Cheff, UpdateCheffDto>().ReverseMap();
            CreateMap<Cheff, CreateCheffDto>().ReverseMap();
            CreateMap<Cheff, ResultCheffDto>().ReverseMap();
            CreateMap<UpdateCheffDto, ResultCheffDto>().ReverseMap();
        }
    }
}
