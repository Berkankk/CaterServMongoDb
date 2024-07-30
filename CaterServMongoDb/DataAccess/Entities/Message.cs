using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MessageID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime Date { get; set; }
    }
}
