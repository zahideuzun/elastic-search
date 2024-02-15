using ElasticSearch.AppCore.DTOs.ProductDTOs;
using ElasticSearch.AppCore.Entities.Product.Product;
using Nest;
using System.Collections.Immutable;

namespace ElasticSearch.DAL.Repositories.Infrastructor
{
    public interface IProductRepository
    {
        public Task<Product?> SaveAsync(Product newProduct);

        public Task<ImmutableList<Product>> GetAllAsync();

        public Task<Product?> GetByIdAsync(string id);

        public Task<bool> UpdateAsync(ProductUpdateDto updateDto);

        public Task<DeleteResponse> DeleteAsync(string id);
    }
}
