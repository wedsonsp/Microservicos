using Catalog.API.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        // Verifica se há dados na coleção.
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        public static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Laptop Dell XPS 13",
                    Category = "Computadores",
                    Description = "Laptop ultrafino e leve com tela InfinityEdge.",
                    Image = "https://example.com/images/dell-xps-13.jpg",
                    Price = "999.99"
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Smartphone Samsung Galaxy S21",
                    Category = "Smartphones",
                    Description = "Smartphone com câmera de 64 MP e tela de 6.2 polegadas.",
                    Image = "https://example.com/images/samsung-galaxy-s21.jpg",
                    Price = "799.99"
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Fone de Ouvido Bluetooth Sony WH-1000XM4",
                    Category = "Acessórios",
                    Description = "Fones com cancelamento de ruído e som de alta qualidade.",
                    Image = "https://example.com/images/sony-wh-1000xm4.jpg",
                    Price = "349.99"
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Monitor LG UltraWide",
                    Category = "Monitores",
                    Description = "Monitor UltraWide de 34 polegadas, ideal para multitarefas.",
                    Image = "https://example.com/images/lg-ultrawide.jpg",
                    Price = "599.99"
                },
                new Product()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Teclado Mecânico Razer BlackWidow",
                    Category = "Acessórios",
                    Description = "Teclado mecânico com retroiluminação RGB e switches responsivos.",
                    Image = "https://example.com/images/razer-blackwidow.jpg",
                    Price = "129.99"
                }
            };
        }
    }
}
