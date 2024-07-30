using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.EventCategoryDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class EventCategoryService : IEventCategoryService
    {
        private readonly IMongoCollection<EventCategories> _eventCategoryCollection;
        private readonly IMapper _mapper;

        public EventCategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _eventCategoryCollection = dataBase.GetCollection<EventCategories>(databaseSettings.EventCategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateEventCategory(CreateEventCategoryDto eventCategoryDto)
        {
            var value = _mapper.Map<EventCategories>(eventCategoryDto);
            await _eventCategoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteEventCategory(string id)
        {
            await _eventCategoryCollection.DeleteOneAsync(x => x.EventCategoriesID == id);
        }

        public async Task<List<ResultEventCategoryDto>> GetAllEventCategorys()
        {
            var value = await _eventCategoryCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultEventCategoryDto>>(value);
        }

        public async Task<ResultEventCategoryDto> GetEventCategoryById(string id)
        {
            var value = await _eventCategoryCollection.Find(x => x.EventCategoriesID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventCategoryDto>(value);
        }

        public async Task UpdateEventCategory(UpdateEventCategoryDto eventCategoryDto)
        {
            var value = _mapper.Map<EventCategories>(eventCategoryDto);
            await _eventCategoryCollection.FindOneAndReplaceAsync(x => x.EventCategoriesID == eventCategoryDto.EventCategoriesID, value);
        }
    }
}
