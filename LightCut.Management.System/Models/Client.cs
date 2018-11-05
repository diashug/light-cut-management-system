using System;
namespace LightCut.Management.System.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Vat { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Locality { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
