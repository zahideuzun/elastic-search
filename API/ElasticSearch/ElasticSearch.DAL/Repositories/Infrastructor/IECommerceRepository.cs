using ElasticSearch.AppCore.DTOs.ECommerceDTOs;
using ElasticSearch.AppCore.Entities.ECommerceModel;
using System.Collections.Immutable;

namespace ElasticSearch.DAL.Repositories.Infrastructor
{
	public interface IECommerceRepository
	{
        #region API

        
        public Task<ImmutableList<ECommerce>> TermQueryAsync(string customerFirstName);

        public Task<ImmutableList<ECommerce>> TermsQueryAsync(List<string> customerFirstNameList);

        public Task<ImmutableList<ECommerce>> PrefixQueryAsync(string customerFullName);

        public Task<ImmutableList<ECommerce>> RangeQueryAsync(double fromPrice, double toPrice);

        public Task<ImmutableList<ECommerce>> PriceRangeQueryByDateAsync(double fromPrice, double toPrice, DateTime fromDate, DateTime toDate);
        public Task<ImmutableList<ECommerce>> DateRangeQueryAsync(DateTime fromDate, DateTime toDate);

        public Task<ImmutableList<ECommerce>> MatchAllQueryAsync();

        public Task<ImmutableList<ECommerce>> PaginationQueryAsync(int page, int pageSize);

        public Task<ImmutableList<ECommerce>> WildCardQueryAsync(string customerFullName);

        public Task<ImmutableList<ECommerce>> FuzzyQueryAsync(string customerFirstName);

        public Task<ImmutableList<ECommerce>> MatchQueryFullTextAsync(string categoryName);

        public Task<ImmutableList<ECommerce>> MultiMatchQueryFullTextAsync(string name);

        public Task<ImmutableList<ECommerce>> MatchBoolPrefixQueryFullTextAsync(string customerFullName);

        public Task<ImmutableList<ECommerce>> MatchPhraseQueryFullTextAsync(string customerFullName);

        public Task<ImmutableList<ECommerce>> CompoundQueryAsync(string cityName, double taxfulTotalPrice, string category, string manufacturer);

        public Task<ImmutableList<ECommerce>> CompoundFullTextAndTermQueryAsync(string customerFullName);

        #endregion

        #region Web-UI

        public Task<(List<ECommerce> list, long count)> SearchAsync(ECommerceSearchDto filter, int page, int pageSize);
		#endregion
	}
}
