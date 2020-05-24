using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LightCut.Models
{
    public class Material
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        public float Price { get; set; }

        [BsonElement("stock")]
        public int Stock { get; set; }

        [BsonElement("stockUnits")]
        public string StockUnits { get; set; }
    }
}
