using ElasticSearch.AppCore.DTOs;
using ElasticSearch.AppCore.Entities;
using ElasticSearch.DAL.Repositories.Infrastructor;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.DAL.Repositories.Derived
{
    public class ProductRepository : IProductRepository
    {
        private readonly IElasticClient _client;

        public ProductRepository(IElasticClient client)
        {
            _client = client;
        }

        //products indexini olusturuyorum ve her product bu indexe kaydoluyor.
        public async Task<Product?> SaveAsync(Product newProduct)
        {
            newProduct.Created = DateTime.Now;
         
            var response = await _client.IndexAsync(newProduct, x => x.Index("products"));

            if (!response.IsValid) return null;

            newProduct.Id = response.Id;

            return newProduct;
        }


    }
}
