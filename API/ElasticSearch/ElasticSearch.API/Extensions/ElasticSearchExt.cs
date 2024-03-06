using Elasticsearch.Net;
using Nest;

namespace ElasticSearch.API.Extensions
{
    public static class ElasticSearchExt
    {
        public static void AddElastic(this IServiceCollection services,IConfiguration configuration)
        {
			////ünlem isareti get sectiondan aldigim degerin var oldugunu belirtmek icin. ünlem koymazsam warning olarak var mi yok mu ne biliyim diyor? runtimeda bir problem yaratmaz compileri rahatlatmak icin. 
			//var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]!));
			//var settings = new ConnectionSettings(pool);

			////elasticClient thread safedir. multi-thread programming yapilabilir.
			
			var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]!));
			var settings = new ConnectionSettings(pool)
				.BasicAuthentication(configuration["Elastic:Username"]!, configuration["Elastic:Password"]!);

			var client = new ElasticClient(settings);

			services.AddSingleton(client);
        }
    }
}
