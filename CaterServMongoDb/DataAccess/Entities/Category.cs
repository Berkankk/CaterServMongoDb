using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class Category
    {
        [BsonId] //Binary search olarak çalışır 
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        [BsonIgnore]
        public List<Product> Products { get; set; }
    }
}
