using ElasticSearch.AppCore.DTOs.BlogDTOs;
using ElasticSearch.AppCore.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.BLL.Abstract
{
    public interface IBlogService
    {
        public Task<bool> Save(BlogCreateDto newBlog);

        public Task<List<Blog>> Search(string searchText);
    }
}
