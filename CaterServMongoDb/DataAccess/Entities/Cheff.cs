using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class Cheff
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CheffID { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
