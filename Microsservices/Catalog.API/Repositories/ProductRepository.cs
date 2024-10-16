﻿using Catalog.API.Data;
using Catalog.API.Model;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
           await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            // Cria um filtro baseado no ID do produto
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            // Executa a exclusão
            DeleteResult deleteResult = await _context.Products.DeleteManyAsync(filter);

            // Verifica se a operação foi reconhecida e se algum item foi excluído
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }


        public async Task<Product> GetProduct(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult  = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            // Verifica se a operação foi reconhecida e se algum item foi modificado
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
