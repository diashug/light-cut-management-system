using LightCut.Management.System.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LightCutAPI.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderService(IConfiguration config)
        {
            var mongoClient = new MongoClient(config.GetConnectionString("LightcutDB"));
            var database = mongoClient.GetDatabase(config["Database"]);
            this._collection = database.GetCollection<Order>("orders");
        }

        public List<Order> Get()
        {
            return _collection.Find(order => true).ToList();
        }

        public Order Get(string id)
        {
            return _collection.Find(order => order.Id == id).FirstOrDefault();
        }

        public Order Create(Order order)
        {
            _collection.InsertOne(order);

            return order;
        }

        public void Update(string id, Order orderIn)
        {
            _collection.ReplaceOne(order => order.Id == id, orderIn);
        }

        public void Remove(Order orderIn)
        {
            _collection.DeleteOne(order => order.Id == orderIn.Id);
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(order => order.Id == id);
        }
    }
}
