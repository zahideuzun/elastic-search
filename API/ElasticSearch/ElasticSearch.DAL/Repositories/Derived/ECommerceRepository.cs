using ElasticSearch.AppCore.Entities.ECommerceModel;
using ElasticSearch.DAL.Repositories.Infrastructor;
using Nest;
using ElasticSearch.DAL.Repositories.Derived.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticSearch.AppCore.DTOs.ECommerceDTOs;

namespace ElasticSearch.DAL.Repositories.Derived
{
	public class ECommerceRepository : IECommerceRepository
	{
		private readonly IElasticClient _client;
		private const string indexName = "kibana_sample_data_ecommerce";

		public ECommerceRepository(IElasticClient client)
		{
			_client = client;
		}

		#region API



		public async Task<ImmutableList<ECommerce>> TermQueryAsync(string customerFirstName)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Query(q => q
					.Term(t => t
						.Field(f => f.CustomerFirstName.Suffix("keyword"))
						.Value(customerFirstName)
					)
				)
			);

			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		//birden fazla first name aratabilirim
		public async Task<ImmutableList<ECommerce>> TermsQueryAsync(List<string> customerFirstNameList)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Size(100)
				.Query(q => q
					.Terms(t => t
						.Field(f => f.CustomerFirstName.Suffix("keyword"))
						.Terms(customerFirstNameList)
					)
				)
			);
			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}


		//yazdigimiz kelime ile baslayanlari getirir. startWith'e benzer.
		public async Task<ImmutableList<ECommerce>> PrefixQueryAsync(string customerFullName)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Size(100)
				.Query(q => q
					.Prefix(p => p
						.Field(f => f.CustomerFullName
						.Suffix("keyword"))
						.Value(customerFullName)
					)
				)
			);
			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> RangeQueryAsync(double fromPrice, double toPrice)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Size(100)
				.Query(q => q
					.Range(r => r
						.Field(f => f.TaxfulTotalPrice)
						.GreaterThanOrEquals(fromPrice)
						.LessThanOrEquals(toPrice)
					)
				)
			);
			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> PriceRangeQueryByDateAsync(double fromPrice, double toPrice, DateTime fromDate, DateTime toDate)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Size(100)
				.Query(q => q
					.Bool(b => b
						.Must(
							bs => bs.Range(r => r
								.Field(f => f.TaxfulTotalPrice)
								.GreaterThanOrEquals(fromPrice)
								.LessThanOrEquals(toPrice)),
							bs => bs.DateRange(dr => dr
								.Field(f => f.OrderDate)
								.GreaterThanOrEquals(fromDate)
								.LessThanOrEquals(toDate))
						)
					)
				)
			);
			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> DateRangeQueryAsync(DateTime fromDate, DateTime toDate)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Size(100)
				.Query(q => q
					.DateRange(dr => dr
						.Field(f => f.OrderDate)
						.GreaterThanOrEquals(fromDate)
						.LessThanOrEquals(toDate)
					)
				)
			);
			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> MatchAllQueryAsync()
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Size(200)
				.Query(q => q
					.MatchAll()
				)
			);
			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> PaginationQueryAsync(int page, int pageSize)
		{
			var pageFrom = (page - 1) * pageSize;

			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Size(pageSize)
				.From(pageFrom)
				.Query(q => q
					.MatchAll()
				)
			);
			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> WildCardQueryAsync(string customerFullName)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
			.Index(indexName)
			.Query(q => q
			.Wildcard(w => w
				.Field(f => f.CustomerFullName
					.Suffix("keyword"))
					.Wildcard(customerFullName))));

			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> FuzzyQueryAsync(string customerFirstName)
		{
			//fuzzines degerini otomatik ayarlarsam kelime uzunluguna göre default olarak ayarliyor.
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Size(100)
				.Query(q => q
					.Fuzzy(f => f
						.Field(fd => fd.CustomerFirstName
						.Suffix("keyword"))
						.Value(customerFirstName)
						.Fuzziness(Fuzziness.AutoLength(1, 2)))
					).Sort(s => s
					 .Ascending(a => a.TaxfulTotalPrice)
			));

			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		//burada women's ve women's shoes araması yap. shoes yaparken Size(500) ekle defaultta or ile arama yaptigini göster. .Operator(Operator.And) ekle and ile yapilabildigini de göster.
		public async Task<ImmutableList<ECommerce>> MatchQueryFullTextAsync(string categoryName)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Query(q => q
					.Match(m => m
						.Field(f => f.Category)
						.Query(categoryName)
					)
				)
			);

			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> MultiMatchQueryFullTextAsync(string name)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Query(q => q
					.MultiMatch(m => m
						.Fields(f => f
							.Field(ff => ff.CustomerFullName)
							.Field(ff => ff.CustomerFirstName)
							.Field(ff => ff.CustomerLastName)
						)
						.Query(name)
					)
				)
			);

			ExtensionsMethod.SetDocumentIds(searchResponse);
			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}


		public async Task<ImmutableList<ECommerce>> MatchBoolPrefixQueryFullTextAsync(string customerFullName)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Query(q => q
					.MatchBoolPrefix(m => m
						.Field(f => f.CustomerFullName)
						.Query(customerFullName)
					)
				)
			);

			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> MatchPhraseQueryFullTextAsync(string customerFullName)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Query(q => q
					.MatchPhrase(m => m
						.Field(f => f.CustomerFullName)
						.Query(customerFullName)
					)
				)
			);

			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> CompoundQueryAsync(string cityName, double taxfulTotalPrice, string category, string manufacturer)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Query(q => q
					.Bool(b => b
						.Must(mu => mu
							.Term(t => t
								.Field("geoip.city_name")
								.Value(cityName)
							)
						)
						.MustNot(mn => mn
							.Range(r => r
								.Field(f => f.TaxfulTotalPrice)
								.LessThanOrEquals(taxfulTotalPrice)
							)
						)
						.Should(sh => sh
							.Term(t => t
								.Field(f => f.Category.Suffix("keyword"))
								.Value(category)
							)
						)
						.Filter(fi => fi
							.Term(t => t
								.Field("manufacturer.keyword")
								.Value(manufacturer)
							)
						)
					)
				)
			);

			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}

		public async Task<ImmutableList<ECommerce>> CompoundFullTextAndTermQueryAsync(string customerFullName)
		{
			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
				.Index(indexName)
				.Query(q => q
					.Bool(b => b
						.Should(sh => sh
							.Match(m => m
								.Field(f => f.CustomerFullName)
								.Query(customerFullName)
							),
							sh => sh
							.Prefix(p => p
								.Field(f => f.CustomerFullName.Suffix("keyword"))
								.Value(customerFullName)
							)
						)
					)
				)
			);

			//var searchResponse = await _client.SearchAsync<ECommerce>(s => s
			//    .Index(indexName)
			//    .Query(q => q
			//        .MatchPhrasePrefix(m => m
			//            .Field(f => f.CustomerFullName)
			//                .Query(customerFullName))));

			ExtensionsMethod.SetDocumentIds(searchResponse);

			return ExtensionsMethod.HandleSearchResponse(searchResponse);
		}



		#endregion


		public async Task<(List<ECommerce> list, long count)> SearchAsync(ECommerceSearchDto eCommerceDtoFilter, int page, int pageSize)
		{
			List<Func<QueryContainerDescriptor<ECommerce>, QueryContainer>> listQuery = new List<Func<QueryContainerDescriptor<ECommerce>, QueryContainer>>();

			if (eCommerceDtoFilter is null)
			{
				listQuery.Add(g => g.MatchAll());
				return await CalculateResultSet(page, pageSize, listQuery);
			}

			if (!string.IsNullOrWhiteSpace(eCommerceDtoFilter.CustomerFullName))
			{
				listQuery.Add(g => g
				.Match(m => m
				.Field(f => f.CustomerFullName)
				.Query(eCommerceDtoFilter.CustomerFullName)));
			}
			if (!string.IsNullOrWhiteSpace(eCommerceDtoFilter.Category))
			{
				listQuery.Add(g => g
				.Match(t => t
				.Field(f => f.Category)
				.Query(eCommerceDtoFilter.Category)));
			}
			if (!string.IsNullOrWhiteSpace(eCommerceDtoFilter.Gender))
			{
				listQuery.Add(g => g
				.Term(t => t
				.Field(f => f.Gender)
				.Value(eCommerceDtoFilter.Gender).CaseInsensitive()));
			}
			if (eCommerceDtoFilter.OrderDateStart.HasValue)
			{
				listQuery.Add(g => g
				.DateRange(dr => dr
				.Field(f => f.OrderDate)
				.GreaterThanOrEquals(eCommerceDtoFilter.OrderDateStart.Value)));
			}
			if (eCommerceDtoFilter.OrderDateEnd.HasValue)
			{
				listQuery.Add(g => g
				.DateRange(dr => dr
				.Field(f => f.OrderDate)
				.LessThanOrEquals(eCommerceDtoFilter.OrderDateEnd.Value)));
			}

			if (!listQuery.Any())
			{
				listQuery.Add(g => g.MatchAll());
			}

			return await CalculateResultSet(page, pageSize, listQuery);

		}

		private async Task<(List<ECommerce> list, long count)> CalculateResultSet(int page, int pageSize, List<Func<QueryContainerDescriptor<ECommerce>, QueryContainer>> listQuery)
		{
			var searchQuery = new QueryContainerDescriptor<ECommerce>()
				.Bool(b => b
				.Must(listQuery.ToArray()));

			var searchResponse = await _client.SearchAsync<ECommerce>(s => s
			   .Index(indexName)
			   .Query(_ => searchQuery)
			   .From((page - 1) * pageSize)
			   .Size(pageSize)
		   );
			foreach (var hit in searchResponse.Hits) hit.Source.Id = hit.Id;

			if (!searchResponse.IsValid)
			{
				throw new Exception(searchResponse.DebugInformation);
			}

			return (list: searchResponse.Documents.ToList(), searchResponse.Total);
		}

	}
}
