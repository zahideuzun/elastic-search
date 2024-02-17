using Nest;

namespace ElasticSearch.AppCore.Entities.Blog
{
    public class Blog
    {
        [PropertyName("_id")]
        public string Id { get; set; } = null!;

        [PropertyName("title")]
        public string Title { get; set; } = null!;

        [PropertyName("content")]
        public string Content { get; set; } = null!;

        [PropertyName("tags")]
        public string[] Tags { get; set; } = null!;

        [PropertyName("user_id")]
        public Guid UserId { get; set; }

        [PropertyName("created")]
        public DateTime Created { get; set; }

    }
}
