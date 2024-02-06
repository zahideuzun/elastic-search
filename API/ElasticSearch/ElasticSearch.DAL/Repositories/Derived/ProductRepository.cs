using ElasticSearch.AppCore.DTOs;
using ElasticSearch.AppCore.Entities;
using ElasticSearch.DAL.Repositories.Infrastructor;
using Nest;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.DAL.Repositories.Derived
{
    public class ProductRepository : IProductRepository
    {
        private readonly IElasticClient _client;
        private const string indexName = "products";
        public ProductRepository(IElasticClient client)
        {
            _client = client;
        }

        //products indexini olusturuyorum ve her product bu indexe kaydoluyor.
        public async Task<Product?> SaveAsync(Product newProduct)
        {
            newProduct.Created = DateTime.Now;
         
            //burada id vermezsem elastic search kendisi id atamasi yapar. best practice bizim id kismini kendimizin bu sekilde guid olarak vermemizdir. 
            var response = await _client.IndexAsync(newProduct, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));

            if (!response.IsValid) return null;

            newProduct.Id = response.Id;

            return newProduct;
        }

        public async Task<ImmutableList<Product>> GetAllAsync()
        {
            var result = await _client.SearchAsync<Product>(
                s=>s.Index(indexName)
                .Query(q=>q.MatchAll()));

            //document icinde id fieldi yok. document hits icindeki source'dan besleniyor. benim id fieldlarim hits icinde. hits icindeki idyi alip hits source'daki idye vermem gerek.
            foreach (var hit in result.Hits) hit.Source.Id = hit.Id;
            
            //immutable list donuyorum degistirilememesi icin. 
            return result.Documents.ToImmutableList();
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            var response = await _client.GetAsync<Product>(id, x=> x.Index(indexName));

            if (!response.IsValid) return null;

            response.Source.Id = response.Id;
            return response.Source;
        }
    }
}
