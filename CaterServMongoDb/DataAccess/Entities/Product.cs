using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public bool IsVegetarian { get; set; }

        [BsonIgnore] //Bunu kullanma sebebimiz ilişkili tabloda tabloya dahil edilmesi için yapıyoruz
        public Category Category { get; set; }

    }
}
