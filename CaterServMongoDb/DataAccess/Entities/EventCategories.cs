using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class EventCategories
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventCategoriesID { get; set; }

        public string CategoryName { get; set; }

        [BsonIgnore]
        public List<Event> Events { get; set; }  //Liste türünde eventleri tuttuk
    }
}
