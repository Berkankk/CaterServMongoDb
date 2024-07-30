using CaterServMongoDb.DataAccess.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDb.Dtos.EventCategoryDtos
{
    public class ResultEventCategoryDto
    {
        public string EventCategoriesID { get; set; }

        public string CategoryName { get; set; }

        [BsonIgnore]
        public List<Event> Events { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
