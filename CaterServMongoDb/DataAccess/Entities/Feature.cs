using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
