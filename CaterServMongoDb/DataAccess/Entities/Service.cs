﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CaterServMongoDb.DataAccess.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceID { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Descripition { get; set; }
    }
}
