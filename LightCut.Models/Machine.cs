using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LightCut.Models
{
    public class Machine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("brand")]
        public string Brand { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("serialNumber")]
        public string SerialNumber { get; set; }
    }
}
