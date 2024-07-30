using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.EventDtos;

namespace CaterServMongoDb.Mapping
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {
            CreateMap<Event, UpdateEventDto>().ReverseMap();
            CreateMap<Event, ResultEventDto>().ReverseMap();
            CreateMap<Event, CreateEventDto>().ReverseMap();
            CreateMap<UpdateEventDto, ResultEventDto>().ReverseMap();
        }
    }
}