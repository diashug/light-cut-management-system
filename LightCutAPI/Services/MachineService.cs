using LightCut.Management.System.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LightCutAPI.Services
{
    public class MachineService
    {
        private readonly IMongoCollection<Machine> _collection;

        public MachineService(IConfiguration config)
        {
            var mongoClient = new MongoClient(config.GetConnectionString("LightcutDB"));
            var database = mongoClient.GetDatabase(config["Database"]);
            this._collection = database.GetCollection<Machine>("machines");
        }

        public List<Machine> Get()
        {
            return _collection.Find(machine => true).ToList();
        }

        public Machine Get(string id)
        {
            return _collection.Find(machine => machine.Id == id).FirstOrDefault();
        }

        public Machine Create(Machine machine)
        {
            _collection.InsertOne(machine);

            return machine;
        }

        public void Update(string id, Machine machineInput)
        {
            _collection.ReplaceOne(machine => machine.Id == id, machineInput);
        }

        public void Remove(Machine machineInput)
        {
            _collection.DeleteOne(machine => machine.Id == machineInput.Id);
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(machine => machine.Id == id);
        }
    }
}
