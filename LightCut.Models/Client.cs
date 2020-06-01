using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LightCut.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("vatNumber")]
        public int VatNumber { get; set; }

        [BsonElement("phoneNumber")]
        public int PhoneNumber { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("postalCode")]
        public string PostalCode { get; set; }

        [BsonElement("locality")]
        public string Locality { get; set; }

        [BsonElement("district")]
        public string District { get; set; }
    }
}
