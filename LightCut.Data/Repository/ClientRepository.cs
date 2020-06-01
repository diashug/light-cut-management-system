using LightCut.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LightCut.Data.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly IMongoCollection<Client> _collection;

        public ClientRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);
            
            _collection = db.GetCollection<Client>(databaseSettings.ClientsCollection);
        }

        public void Add(Client entity)
        {
            _collection.InsertOne(entity);
        }

        public Client Get(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<Client> GetAll()
        {
            return _collection.Find(c => true).ToList();
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(c => c.Id == id);
        }

        public void Remove(Client entity)
        {
            _collection.DeleteOne(c => c.Id == entity.Id);
        }

        public void Update(Client entity)
        {
            _collection.ReplaceOne(c => c.Id == entity.Id, entity);
        }
    }
}
