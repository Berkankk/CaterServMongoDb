using CaterServMongoDb.Dtos.EventDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IEventService
    {
        Task<List<ResultEventDto>> GetAllEvents();
        Task<ResultEventDto> GetEventById(string id);
        Task UpdateEvent(UpdateEventDto eventDto);
        Task CreateEvent(CreateEventDto eventDto);
        Task DeleteEvent(string id);
        Task<List<ResultEventDto>> GetEventsWithCategories();
    }
}
