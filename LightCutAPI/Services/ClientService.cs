using LightCutAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LightCutAPI.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _collection;

        public ClientService(IConfiguration config)
        {
            var mongoClient = new MongoClient(config.GetConnectionString("LightcutDB"));
            var database = mongoClient.GetDatabase(config["Database"]);
            this._collection = database.GetCollection<Client>("clients");
        }

        public List<Client> Get()
        {
            return _collection.Find(client => true).ToList();
        }

        public Client Get(string id)
        {
            return _collection.Find(client => client.Id == id).FirstOrDefault();
        }

        public Client Create(Client client)
        {
            _collection.InsertOne(client);

            return client;
        }

        public void Update(string id, Client clientInput)
        {
            _collection.ReplaceOne(client => client.Id == id, clientInput);
        }

        public void Remove(Client clientInput)
        {
            _collection.DeleteOne(client => client.Id == clientInput.Id);
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(client => client.Id == id);
        }
    }
}
