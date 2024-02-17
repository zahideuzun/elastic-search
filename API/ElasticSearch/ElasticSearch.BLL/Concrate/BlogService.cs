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
        public async Task<bool> Save(BlogCreateDto newBlog)
        {
            var blog = _mapper.Map<Blog>(newBlog);

            var isCreated= await _blogRepository.SaveAsync(blog);

            return isCreated != null;
        }

        public async Task<List<BlogDto>> Search(string searchText)
        {
            var blogList = await _blogRepository.SearchAsync(searchText);

			var blogViewModels = blogList.Select(blog => new BlogDto
			{
				Id = blog.Id,
				Title = blog.Title,
				Content = blog.Content,
				Tags = String.Join(",", blog.Tags), 
				UserId = blog.UserId.ToString(),
				Created = blog.Created.ToShortDateString() 
			}).ToList();

            return blogViewModels;
		}
    }
}
