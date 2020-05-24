using LightCut.Management.System.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LightCutAPI.Services
{
    public class MaterialService
    {
        private readonly IMongoCollection<Material> _collection;

        public MaterialService(IConfiguration config)
        {
            var mongoClient = new MongoClient(config.GetConnectionString("LightcutDB"));
            var database = mongoClient.GetDatabase(config["Database"]);
            this._collection = database.GetCollection<Material>("materials");
        }

        public List<Material> Get()
        {
            return _collection.Find(material => true).ToList();
        }

        public Material Get(string id)
        {
            return _collection.Find(material => material.Id == id).FirstOrDefault();
        }

        public Material Create(Material material)
        {
            _collection.InsertOne(material);

            return material;
        }

        public void Update(string id, Material materialInput)
        {
            _collection.ReplaceOne(material => material.Id == id, materialInput);
        }

        public void Remove(Machine machineIn)
        {
            _collection.DeleteOne(material => material.Id == machineIn.Id);
        }

        public void Remove(string id)
        {
            _collection.DeleteOne(material => material.Id == id);
        }
    }
}
