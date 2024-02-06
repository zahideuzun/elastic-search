using ElasticSearch.AppCore.Entities;

namespace ElasticSearch.DAL.Repositories.Infrastructor
{
    public interface IProductRepository
    {
        public Task<Product?> SaveAsync(Product newProduct);
    }
}
