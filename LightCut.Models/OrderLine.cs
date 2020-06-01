using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LightCut.Models
{
    public class OrderLine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("materialId")]
        public Material MaterialId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("discount")]
        public float Discount { get; set; }

        [BsonElement("unitPrice")]
        public float UnitPrice { get; set; }

        [BsonElement("vat")]
        public float Vat { get; set; }
    }
}
