using CaterServMongoDb.Dtos.EventCategoryDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IEventCategoryService
    {
        Task<List<ResultEventCategoryDto>> GetAllEventCategorys();
        Task<ResultEventCategoryDto> GetEventCategoryById(string id);
        Task UpdateEventCategory(UpdateEventCategoryDto eventCategoryDto);
        Task CreateEventCategory(CreateEventCategoryDto eventCategoryDto);
        Task DeleteEventCategory(string id);
    }
}
