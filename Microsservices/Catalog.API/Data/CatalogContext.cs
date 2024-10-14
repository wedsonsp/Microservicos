using Catalog.API.Model;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration) 
        {
          var client = new MongoClient(configuration.GetValue<String>
              ("DatabaseSettings:ConnectionString"));

            var dataBase = client.GetDatabase(configuration.GetValue<String>
                ("DatabaseSettings:DatabaseName"));

            Products = dataBase.GetCollection<Product>(configuration.GetValue<String>
                ("DatabaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);

        }
        public IMongoCollection<Product> Products { get; set; }
    }
}
