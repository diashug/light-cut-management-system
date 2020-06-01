﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LightCut.Models
{
    public class Role
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
