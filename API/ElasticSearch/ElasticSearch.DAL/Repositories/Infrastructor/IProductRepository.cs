using ElasticSearch.AppCore.Entities;
using System.Collections.Immutable;

namespace ElasticSearch.DAL.Repositories.Infrastructor
{
    public interface IProductRepository
    {
        public Task<Product?> SaveAsync(Product newProduct);

        public Task<ImmutableList<Product>> GetAllAsync();

        public Task<Product?> GetByIdAsync(string id);
    }
}
