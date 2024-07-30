using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialID { get; set; }

        public string ImageUrl { get; set; }
        public int Star { get; set; }
        public string Name { get; set; }
        public DateTime CommnetDate { get; set; }
        public string Commet { get; set; }
    }
}
