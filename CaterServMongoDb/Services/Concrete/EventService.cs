using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.EventCategoryDtos;
using CaterServMongoDb.Dtos.EventDtos;
using CaterServMongoDb.Services.Abstract;
using CaterServMongoDb.Settings;
using MongoDB.Driver;

namespace CaterServMongoDb.Services.Concrete
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _eventCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<EventCategories> _eventCategoriesCollection;
        private readonly IImageService _imageService;

        public EventService(IMapper mapper, IDatabaseSettings databaseSettings, IImageService imageService)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _eventCollection = dataBase.GetCollection<Event>(databaseSettings.EventCollectionName);
            _eventCategoriesCollection = dataBase.GetCollection<EventCategories>(databaseSettings.EventCategoryCollectionName);
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateEvent(CreateEventDto eventDto)
        {
            var ImageUrl = await _imageService.CreateImage(eventDto.File);
         

            var value = _mapper.Map<Event>(eventDto);
            value.ImageUrl = ImageUrl;
            await _eventCollection.InsertOneAsync(value);
        }

        public async Task DeleteEvent(string id)
        {
            await _eventCollection.DeleteOneAsync(x => x.EventID == id);
        }

        public async Task<List<ResultEventDto>> GetAllEvents()
        {
            var value = await _eventCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultEventDto>>(value);
        }

        public async Task<ResultEventDto> GetEventById(string id)
        {
            var value = await _eventCollection.Find(x => x.EventID == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventDto>(value);
        }

        public async Task<List<ResultEventDto>> GetEventsWithCategories()
        {
            var EventList = await _eventCollection.AsQueryable().ToListAsync();
            List<ResultEventDto> result = new List<ResultEventDto>();
            foreach (var item in EventList)
            {
                var category = _eventCategoriesCollection.Find(x => x.EventCategoriesID == item.EventCategoriesID).FirstOrDefault();
                if (category != null)
                {
                    var mappedValue = _mapper.Map<ResultEventCategoryDto>(category);
                    result.Add(new ResultEventDto
                    {
                        EventCategoriesID = item.EventCategoriesID,
                        ImageUrl = item.ImageUrl,
                        EventID = item.EventID,
                        EventCategory = mappedValue,
                    });
                }
            }
            return result;
        }

        public async Task UpdateEvent(UpdateEventDto eventDto)
        {
            var ImageUrl = await _imageService.CreateImage(eventDto.File);
            eventDto.ImageUrl = ImageUrl;

            var value = _mapper.Map<Event>(eventDto);
            await _eventCollection.FindOneAndReplaceAsync(x => x.EventID == value.EventID, value);
        }
    }
}
