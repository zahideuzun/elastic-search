using ElasticSearch.AppCore.DTOs.BlogDTOs;
using ElasticSearch.AppCore.DTOs.ECommerceDTOs;
using ElasticSearch.AppCore.Entities.ECommerceModel;

namespace ElasticSearch.BLL.Abstract
{
	public interface IBlogService
    {
        public Task<bool> Save(BlogCreateDto newBlog);

        public Task<List<BlogDto>> Search(string searchText);

	}
}
