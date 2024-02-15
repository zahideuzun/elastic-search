using AutoMapper;
using ElasticSearch.AppCore.DTOs.BlogDTOs;
using ElasticSearch.AppCore.Entities.Blog;
using ElasticSearch.BLL.Abstract;
using ElasticSearch.DAL.Repositories.Infrastructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.BLL.Concrate
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<bool> SaveAsync(BlogCreateDto newBlog)
        {
            var blog = _mapper.Map<Blog>(newBlog);

            var isCreated= await _blogRepository.SaveAsync(blog);

            return isCreated != null;
        }
    }
}
