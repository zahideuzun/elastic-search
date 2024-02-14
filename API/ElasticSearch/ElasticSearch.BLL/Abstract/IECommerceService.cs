
using ElasticSearch.AppCore.Entities.ECommerceModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.BLL.Abstract
{
    public interface IECommerceService
    {
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
    }
}
