using LightCutAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LightCutAPI.Services
{
    public class DeliveryMethodService
    {
        private readonly IMongoCollection<DeliveryMethod> _collection;

        public DeliveryMethodService(IConfiguration config)
        {
            var mongoClient = new MongoClient(config.GetConnectionString("LightcutDB"));
            var database = mongoClient.GetDatabase(config["Database"]);
            this._collection = database.GetCollection<DeliveryMethod>("deliveryMethods");
        }

        public List<DeliveryMethod> Get()
        {
            return _collection.Find(deliveryMethod => true).ToList();
        }

        public DeliveryMethod Get(string id)
        {
            return _collection.Find(deliveryMethod => deliveryMethod.Id == id).FirstOrDefault();
        }

        public DeliveryMethod Create(DeliveryMethod deliveryMethod)
        {
            _collection.InsertOne(deliveryMethod);

            return deliveryMethod;
        }

        public void Update(string id, DeliveryMethod deliveryMethodInput)
        {
            _collection.ReplaceOne(deliveryMethod => deliveryMethod.Id == id, deliveryMethodInput);
        }

        public void Remove(DeliveryMethod deliveryMethodInput)
        {
            _collection.DeleteOne(deliveryMethod => deliveryMethod.Id == deliveryMethodInput.Id);
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(deliveryMethod => deliveryMethod.Id == id);
        }
    }
}
