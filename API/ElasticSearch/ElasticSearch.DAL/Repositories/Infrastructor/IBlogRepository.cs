using ElasticSearch.AppCore.Entities.Blog;

namespace ElasticSearch.DAL.Repositories.Infrastructor
{
	public interface IBlogRepository
    {
        public Task<Blog?> SaveAsync(Blog newBlog);

        public Task<List<Blog>> SearchAsync(string searchText);
    }
}
