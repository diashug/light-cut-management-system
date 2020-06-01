using LightCut.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightCut.Data.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = db.GetCollection<Order>(databaseSettings.OrdersCollection);
        }

        public void Add(Order entity)
        {
            _collection.InsertOne(entity);
        }

        public Order Get(string id)
        {
            return _collection.Find(order => order.Id == id).FirstOrDefault();
        }

        public IEnumerable<Order> GetAll()
        {
            return _collection.Find(order => true).ToList();
        }

        public bool Remove(string id)
        {
            var result = _collection.DeleteOne(order => order.Id == id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Remove(Order entity)
        {
            var result = _collection.DeleteOne(order => order.Id == entity.Id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Update(Order entity)
        {
            var result = _collection.ReplaceOne(order => order.Id == entity.Id, entity);

            return (result.IsAcknowledged && (result.ModifiedCount > 0));
        }
    }
}
