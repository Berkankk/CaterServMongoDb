using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
}
