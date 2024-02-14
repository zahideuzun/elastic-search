
using ElasticSearch.AppCore.Entities.ECommerceModel;
using Nest;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.DAL.Repositories.Infrastructor
{
    public interface IECommerceRepository 
    {
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

        public Task<ImmutableList<ECommerce>> MatchBoolPrefixQueryFullTextAsync(string customerFullName);

        public Task<ImmutableList<ECommerce>> MatchPhraseQueryFullTextAsync(string customerFullName);

        public Task<ImmutableList<ECommerce>> CompoundQueryAsync(string cityName, double taxfulTotalPrice, string category, string manufacturer);
    }
}
