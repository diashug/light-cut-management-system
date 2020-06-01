using LightCut.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightCut.Data.Repository
{
    public class MaterialsRepository : IRepository<Material>
    {
        private readonly IMongoCollection<Material> _collection;

        public MaterialsRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = db.GetCollection<Material>(databaseSettings.MaterialsCollection);
        }

        public void Add(Material entity)
        {
            _collection.InsertOne(entity);
        }

        public Material Get(string id)
        {
            return _collection.Find(material => material.Id == id).FirstOrDefault();
        }

        public IEnumerable<Material> GetAll()
        {
            return _collection.Find(material => true).ToList();
        }

        public bool Remove(string id)
        {
            var result = _collection.DeleteOne(material => material.Id == id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Remove(Material entity)
        {
            var result = _collection.DeleteOne(material => material.Id == entity.Id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Update(Material entity)
        {
            var result = _collection.ReplaceOne(material => material.Id == entity.Id, entity);

            return (result.IsAcknowledged && (result.ModifiedCount > 0));
        }
    }
}
