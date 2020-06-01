using LightCut.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightCut.Data.Repository
{
    public class RolesRepository : IRepository<Role>
    {
        private readonly IMongoCollection<Role> _collection;

        public RolesRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = db.GetCollection<Role>(databaseSettings.RolesCollection);
        }

        public void Add(Role entity)
        {
            _collection.InsertOne(entity);
        }

        public Role Get(string id)
        {
            return _collection.Find(role => role.Id == id).FirstOrDefault();
        }

        public IEnumerable<Role> GetAll()
        {
            return _collection.Find(role => true).ToList();
        }

        public bool Remove(string id)
        {
            var result = _collection.DeleteOne(role => role.Id == id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Remove(Role entity)
        {
            var result = _collection.DeleteOne(role => role.Id == entity.Id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Update(Role entity)
        {
            var result = _collection.ReplaceOne(role => role.Id == entity.Id, entity);

            return (result.IsAcknowledged && (result.ModifiedCount > 0));
        }
    }
}
