using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventID { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }

        public string EventCategoriesID { get; set; }

        [BsonIgnore]
        public EventCategories EventCategory { get; set; }
    }
}
