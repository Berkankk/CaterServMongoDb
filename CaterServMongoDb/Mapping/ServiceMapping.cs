using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.ServiceDtos;

namespace CaterServMongoDb.Mapping
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<UpdateServiceDto, ResultServiceDto>().ReverseMap();
        }
    }
}
