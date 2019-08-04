using LightCutAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LightCutAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _collection;

        public UserService(IConfiguration config)
        {
            var mongoClient = new MongoClient(config.GetConnectionString("LightcutDB"));
            var database = mongoClient.GetDatabase(config["Database"]);
            this._collection = database.GetCollection<User>("users");
        }

        public List<User> Get()
        {
            return _collection.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            return _collection.Find(user => user.Id == id).FirstOrDefault();
        }

        public User Create(User user)
        {
            _collection.InsertOne(user);

            return user;
        }

        public void Update(string id, User userInput)
        {
            _collection.ReplaceOne(user => user.Id == id, userInput);
        }

        public void Remove(User userInput)
        {
            _collection.DeleteOne(user => user.Id == userInput.Id);
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(user => user.Id == id);
        }
    }
}
