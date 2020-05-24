using LightCut.Management.System.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LightCutAPI.Services
{
    public class SupplierService
    {
        private readonly IMongoCollection<Supplier> _collection;

        public SupplierService(IConfiguration config)
        {
            var mongoClient = new MongoClient(config.GetConnectionString("LightcutDB"));
            var database = mongoClient.GetDatabase(config["Database"]);
            this._collection = database.GetCollection<Supplier>("suppliers");
        }

        public List<Supplier> Get()
        {
            return _collection.Find(supplier => true).ToList();
        }

        public Supplier Get(string id)
        {
            return _collection.Find<Supplier>(supplier => supplier.Id == id).FirstOrDefault();
        }

        public Supplier Create(Supplier supplier)
        {
            _collection.InsertOne(supplier);

            return supplier;
        }

        public void Update(string id, Supplier supplierIn)
        {
            _collection.ReplaceOne(supplier => supplier.Id == id, supplierIn);
        }

        public void Remove(Supplier supplierIn)
        {
            _collection.DeleteOne(supplier => supplier.Id == supplierIn.Id);
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(supplier => supplier.Id == id);
        }
    }
}
