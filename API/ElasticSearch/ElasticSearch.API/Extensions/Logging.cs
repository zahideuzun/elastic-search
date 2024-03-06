using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace ElasticSearch.API.Extensions
{
	public static class Logging
	{
		public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =>
			(context, loggerConfiguration) =>
			{
				var env = context.HostingEnvironment;
				var elasticUrl = context.Configuration.GetSection("Elastic")["Url"]!;

				
				loggerConfiguration.MinimumLevel.Information()
				
				.Enrich.FromLogContext()
				.Enrich.WithProperty("ApplicationName", env.ApplicationName)
				.Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
				
				.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
				.MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
				
				.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUrl))
				{
					
					AutoRegisterTemplate = true,
					AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv8,
					IndexFormat = "log-index-{0:dd.MM.yyyy}", 
					//IndexAliases = new[] { "log-index-{0:dd.MM.yyyy}" },
					BufferFileRollingInterval = RollingInterval.Day,
					MinimumLogEventLevel = LogEventLevel.Debug, 
				});

				if (env.IsDevelopment())
				{
					loggerConfiguration.MinimumLevel.Override("User", LogEventLevel.Debug);
				}
			};
	}

}
