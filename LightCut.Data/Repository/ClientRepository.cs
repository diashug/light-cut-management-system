using LightCut.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LightCut.Data.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly IMongoCollection<Client> _collection;

        public ClientRepository(LightCutDatabaseSettings databaseSettings)//IConfiguration config)
        {
            //var client = new MongoClient(config.GetSection("LightCutDatabaseSettings:ConnectionString").Value);
            //var db = client.GetDatabase(config.GetSection("LightCutDatabaseSettings:DatabaseName").Value);

            //_collection = db.GetCollection<Client>(config.GetSection("LightCutDatabaseSettings:ClientsCollection").Value);

            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = db.GetCollection<Client>(databaseSettings.ClientsCollection);
        }

        public void Add(Client entity)
        {
            _collection.InsertOne(entity);
        }

        public async Task<Client> Get(string id)
        {
            return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _collection.Find(c => true).ToListAsync();
        }

        public async Task<bool> Remove(string id)
        {
            var result = await _collection.DeleteOneAsync(c => c.Id == id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public async Task<bool> Remove(Client entity)
        {
            var result = await _collection.DeleteOneAsync(c => c.Id == entity.Id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public async Task<bool> Update(Client entity)
        {
            var result = await _collection.ReplaceOneAsync(c => c.Id == entity.Id, entity);

            return (result.IsAcknowledged && (result.ModifiedCount > 0));
        }
    }
}
