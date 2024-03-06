using ElasticSearch.AppCore.DTOs.ECommerceDTOs;
using ElasticSearch.AppCore.Entities.ECommerceModel;
using System.Collections.Immutable;

namespace ElasticSearch.BLL.Abstract
{
	public interface IECommerceService
    {
        #region API

        
        public Task<ImmutableList<ECommerce>> TermQuery(string customerFirstName);

        public Task<ImmutableList<ECommerce>> TermsQuery(List<string> customerFirstNameList);

        public Task<ImmutableList<ECommerce>> PrefixQuery(string customerFullName);

        public Task<ImmutableList<ECommerce>> RangeQuery(double fromPrice, double toPrice);

        public Task<ImmutableList<ECommerce>> PriceRangeQueryByDate(double fromPrice, double toPrice, DateTime fromDate, DateTime toDate);
        public Task<ImmutableList<ECommerce>> DateRangeQuery(DateTime fromDate, DateTime toDate);

        public Task<ImmutableList<ECommerce>> MatchAllQuery();

        public Task<ImmutableList<ECommerce>> PaginationQuery(int page, int pageSize);

        public Task<ImmutableList<ECommerce>> WildCardQuery(string customerFullName);

        public Task<ImmutableList<ECommerce>> FuzzyQuery(string customerFirstName);

        public Task<ImmutableList<ECommerce>> MatchQueryFullText(string categoryName);

        public Task<ImmutableList<ECommerce>> MultiMatchQueryFullText(string name);

        public Task<ImmutableList<ECommerce>> MatchBoolPrefixQueryFullText(string customerFullName);

        public Task<ImmutableList<ECommerce>> MatchPhraseQueryFullText(string customerFullName);

        public Task<ImmutableList<ECommerce>> CompoundQuery(string cityName, double taxfulTotalPrice, string category, string manufacturer);

        public Task<ImmutableList<ECommerce>> CompoundFullTextAndTermQuery(string customerFullName);

		#endregion

		#region WEB-UI

		public Task<(List<ECommerceDto>, long totalCount, long pageLinkCount)> SearchAsync(ECommerceSearchDto filter, int page, int pageSize);

		#endregion
	}
}
