using LightCut.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightCut.Data.Repository
{
    public class DeliveryMethodRepository : IRepository<DeliveryMethod>
    {
        private readonly IMongoCollection<DeliveryMethod> _collection;

        public DeliveryMethodRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = db.GetCollection<DeliveryMethod>(databaseSettings.DeliveryMethodsCollection);
        }

        public void Add(DeliveryMethod entity)
        {
            _collection.InsertOne(entity);
        }

        public DeliveryMethod Get(string id)
        {
            return _collection.Find(deliveryMethod => deliveryMethod.Id == id).FirstOrDefault();
        }

        public IEnumerable<DeliveryMethod> GetAll()
        {
            return _collection.Find(deliveryMethod => true).ToList();
        }

        public bool Remove(string id)
        {
            var result = _collection.DeleteOne(deliveryMethod => deliveryMethod.Id == id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Remove(DeliveryMethod entity)
        {
            var result = _collection.DeleteOne(deliveryMethod => deliveryMethod.Id == entity.Id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Update(DeliveryMethod entity)
        {
            var result = _collection.ReplaceOne(deliveryMethod => deliveryMethod.Id == entity.Id, entity);

            return (result.IsAcknowledged && (result.ModifiedCount > 0));
        }
    }
}
