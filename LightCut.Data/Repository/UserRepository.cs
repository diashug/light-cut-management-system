using LightCut.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace LightCut.Data.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = db.GetCollection<User>(databaseSettings.UsersCollection);
        }

        public void Add(User entity)
        {
            _collection.InsertOne(entity);
        }

        public User Get(string id)
        {
            return _collection.Find(user => user.Id == id).FirstOrDefault();
        }

        public bool Get(string username, string password)
        {
            return _collection.Find(user => (user.Username == username) && (user.Password == password)).Any();
        }

        public IEnumerable<User> GetAll()
        {
            var users = this._collection.Find(_ => true).ToList();

            return users;
        }

        public bool Remove(string id)
        {
            var result = _collection.DeleteOne(user => user.Id == id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Remove(User entity)
        {
            var result = _collection.DeleteOne(user => user.Id == entity.Id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Update(User entity)
        {
            var result = _collection.ReplaceOne(user => user.Id == entity.Id, entity);

            return (result.IsAcknowledged && (result.ModifiedCount > 0));
        }
    }
}
