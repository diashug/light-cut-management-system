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
            var mongoClient = new MongoClient(config.GetConnectionString("LightCutDB"));
            var database = mongoClient.GetDatabase(config["Database"]);
            this._collection = database.GetCollection<User>("users");
        }

        public List<User> Get()
        {
            var users = this._collection.Find(_ => true).ToList();

            return users;
        }

        public User Get(string id)
        {
            return _collection.Find(user => user.Id == id).FirstOrDefault();
        }

        public bool Get(string username, string password)
        {
            return _collection.Find(user => (user.Username == username) && (user.Password == password)).Any();
        }

        public User Create(User user)
        {
            _collection.InsertOne(user);

            return user;
        }

        public bool Update(string id, User userInput)
        {
            var result = _collection.ReplaceOne(user => user.Id == id, userInput);

            return (result.IsAcknowledged && (result.ModifiedCount > 0));
        }

        public bool Remove(User userInput)
        {
            var result = _collection.DeleteOne(user => user.Id == userInput.Id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Remove(string id)
        {
            var result = _collection.DeleteOne(user => user.Id == id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }
    }
}
