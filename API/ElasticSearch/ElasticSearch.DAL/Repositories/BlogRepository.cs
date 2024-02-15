using ElasticSearch.AppCore.Entities.Blog;
using ElasticSearch.DAL.Repositories.Infrastructor;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.DAL.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IElasticClient _client;
        private const string indexName = "blog";
        public BlogRepository(IElasticClient client)
        {
            _client = client;
        }

        public async Task<Blog?> SaveAsync(Blog newBlog)
        {
            newBlog.Created = DateTime.Now;

            var response = await _client.IndexAsync(newBlog, x => x.Index(indexName).Id(Guid.NewGuid().ToString()));

            if (!response.IsValid) return null;

            newBlog.Id = response.Id;

            return newBlog;
        }
    }
}
