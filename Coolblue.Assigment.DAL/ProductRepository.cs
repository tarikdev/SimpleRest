using Coolblue.Assigment.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using Coolblue.Assigment.DAL.Entities;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Coolblue.Assigment.DAL
{
    public class ProductRepository:IProductRepository
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<Product> _products;
        public ProductRepository()
        {
            _client = new MongoClient(ConfigurationManager.AppSettings["MongoDBConnectionString"]);
            _database = _client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDatabaseName"]);
            _products = _database.GetCollection<Product>("products");

        }

        #region == Methods ==
        public IEnumerable<Entities.Product> GetAllProducts()
        {
            return _products.AsQueryable<Product>().ToList();
        }

        public Entities.Product GetProduct(string productId)
        {
            return _products.Find(p => p.ProductId == productId).FirstOrDefault();
        }

        public Entities.Product AddProduct(Entities.Product item)
        {
            item.ProductId = ObjectId.GenerateNewId().ToString();
            item.LastModified = DateTime.Now;
            _products.InsertOne(item);
            return item;
        }

        public bool RemoveProduct(string productId)
        {
            var result = _products.DeleteOne(p => p.ProductId == productId);
            return result.IsAcknowledged;
        }

        public bool UpdateProduct(string productId, Entities.Product item)
        {
            item.ProductId = productId;
            var filter = Builders<Product>.Filter.Eq("_id",productId);
            var update = Builders<Product>.Update.Set("_id", productId).Set("Title", item.Title).Set("UnitPrice", item.UnitPrice).Set("LastModified", DateTime.Now).Set("Description", item.Description).
                Set("Category",item.Category);

            var result = _products.UpdateOne(filter, update);

            return result.IsAcknowledged;
        }

        #endregion
    }
}
