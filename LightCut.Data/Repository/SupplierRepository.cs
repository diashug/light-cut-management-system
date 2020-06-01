using LightCut.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightCut.Data.Repository
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private readonly IMongoCollection<Supplier> _collection;

        public SupplierRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = db.GetCollection<Supplier>(databaseSettings.SuppliersCollection);
        }

        public void Add(Supplier entity)
        {
            _collection.InsertOne(entity);
        }

        public Supplier Get(string id)
        {
            return _collection.Find(supplier => supplier.Id == id).FirstOrDefault();
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _collection.Find(supplier => true).ToList();
        }

        public bool Remove(string id)
        {
            var result = _collection.DeleteOne(supplier => supplier.Id == id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Remove(Supplier entity)
        {
            var result = _collection.DeleteOne(supplier => supplier.Id == entity.Id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Update(Supplier entity)
        {
            var result = _collection.ReplaceOne(supplier => supplier.Id == entity.Id, entity);
            
            return (result.IsAcknowledged && (result.ModifiedCount > 0));
        }
    }
}
