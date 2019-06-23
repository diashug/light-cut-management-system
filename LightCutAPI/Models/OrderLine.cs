using LightCut.Management.System.Models;

namespace LightCutAPI.Models
{
    public class OrderLine
    {
        public string Description { get; set; }
        public Material MaterialId { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float UnitPrice { get; set; }
        public float ShippingRate { get; set; }
        public float Vat { get; set; }
    }
}
