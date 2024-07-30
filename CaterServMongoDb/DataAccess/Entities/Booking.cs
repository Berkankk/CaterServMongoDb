using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using CaterServMongoDb.Dtos.EventCategoryDtos;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class Booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookingID { get; set; }
        public string Status { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string NameSurname { get; set; }
        public string PersonCount { get; set; }
        public bool IsVegeteratian { get; set; }
        public string PhoneNumber { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }

        public string EventCategoriesID { get; set; }

        [BsonIgnore]
        public ResultEventCategoryDto EventCategories { get; set; }
    }
}
