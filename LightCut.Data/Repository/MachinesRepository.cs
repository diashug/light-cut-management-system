using LightCut.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightCut.Data.Repository
{
    public class MachinesRepository : IRepository<Machine>
    {
        private readonly IMongoCollection<Machine> _collection;

        public MachinesRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = db.GetCollection<Machine>(databaseSettings.MachinesCollection);
        }

        public void Add(Machine entity)
        {
            _collection.InsertOne(entity);
        }

        public Machine Get(string id)
        {
            return _collection.Find(machine => machine.Id == id).FirstOrDefault();
        }

        public IEnumerable<Machine> GetAll()
        {
            return _collection.Find(machine => true).ToList();
        }

        public bool Remove(string id)
        {
            var result = _collection.DeleteOne(machine => machine.Id == id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Remove(Machine entity)
        {
            var result = _collection.DeleteOne(machine => machine.Id == entity.Id);

            return (result.IsAcknowledged && (result.DeletedCount > 0));
        }

        public bool Update(Machine entity)
        {
            var result = _collection.ReplaceOne(machine => machine.Id == entity.Id, entity);

            return (result.IsAcknowledged && (result.ModifiedCount > 0));
        }
    }
}
