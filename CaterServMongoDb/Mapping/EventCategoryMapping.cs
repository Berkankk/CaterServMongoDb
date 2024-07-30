using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.EventCategoryDtos;

namespace CaterServMongoDb.Mapping
{
    public class EventCategoryMapping : Profile
    {
        public EventCategoryMapping()
        {
            CreateMap<EventCategories,UpdateEventCategoryDto>().ReverseMap();
            CreateMap<EventCategories,CreateEventCategoryDto>().ReverseMap();
            CreateMap<EventCategories,ResultEventCategoryDto>().ReverseMap();
            CreateMap<UpdateEventCategoryDto,ResultEventCategoryDto>().ReverseMap();
        }
    }
}
