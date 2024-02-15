using ElasticSearch.AppCore.Entities.Blog;
using ElasticSearch.DAL.Repositories.Infrastructor;
using Nest;

namespace ElasticSearch.DAL.Repositories.Derived
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

        public async Task<List<Blog>> SearchAsync(string searchText)
        {
            //title ve contentine gore arama yapacagim. full text. 

            var searchResponse = await _client.SearchAsync<Blog>(s => s
                .Index(indexName)
                .Query(q => q
                    .Bool(b => b
                        .Should(sh => sh
                            .Match(m => m
                                .Field(f => f.Content)
                                .Query(searchText)
                            ),
                            sh => sh
                            .MatchBoolPrefix(p => p
                                .Field(f => f.Title)
                                .Query(searchText)
                            )
                        )
                    )
                )
            );

            foreach (var hit in searchResponse.Hits) hit.Source.Id = hit.Id;

            return searchResponse.Documents.ToList();
        }
    }
}
