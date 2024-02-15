using ElasticSearch.AppCore.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.DAL.Repositories.Infrastructor
{
    public interface IBlogRepository
    {
        public Task<Blog?> SaveAsync(Blog newBlog);

        public Task<List<Blog>> SearchAsync(string searchText);
    }
}
