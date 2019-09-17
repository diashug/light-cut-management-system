﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LightCutAPI.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("roleId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoleId { get; set; }
    }
}
