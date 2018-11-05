using System;
namespace LightCut.Management.System.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float UnitPrice { get; set; }

        public Client ClientId { get; set; }
        public Material MaterialId { get; set; }
        public Product ProductId { get; set; }
    }
}
