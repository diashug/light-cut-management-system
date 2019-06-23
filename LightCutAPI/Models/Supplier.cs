using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LightCut.Management.System.Models
{
    public class Supplier
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("nif")]
        public int Nif { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("postalCode")]
        public string PostalCode { get; set; }

        [BsonElement("locality")]
        public string Locality { get; set; }

        [BsonElement("phoneNumber")]
        public int PhoneNumber { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}
