using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace LightCut.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; }

        [BsonElement("shippingDate")]
        public DateTime ShippingDate { get; set; }

        [BsonElement("shippingAddress")]
        public string ShippingAddress { get; set; }

        [BsonElement("shippingRate")]
        public float ShippingRate { get; set; }

        [BsonElement("orderLines")]
        public List<OrderLine> OrderLines { get; set; }

        [BsonElement("observations")]
        public string Observations { get; set; }

        [BsonElement("clientId")]
        public Client ClientId { get; set; }

        [BsonElement("deliveryMethodId")]
        public DeliveryMethod DeliveryMethodId { get; set; }
    }
}
