using ElasticSearch.AppCore.DTOs.ECommerceDTOs;
using ElasticSearch.AppCore.Entities.ECommerceModel;
using ElasticSearch.BLL.Abstract;
using ElasticSearch.DAL.Repositories.Infrastructor;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.BLL.Concrate
{
    public class ECommerceService : IECommerceService
    {
        private readonly IECommerceRepository _repository;

        public ECommerceService(IECommerceRepository repository)
        {
            _repository = repository;
        }

        #region API

        
        public async Task<ImmutableList<ECommerce>> TermQuery(string customerFirstName)
        {
            
            var result = await _repository.TermQueryAsync(customerFirstName);  return result;
        }

        public async Task<ImmutableList<ECommerce>> TermsQuery(List<string> customerFirstNameList)
        {
            var result = await _repository.TermsQueryAsync(customerFirstNameList); return result;
        }

        public async Task<ImmutableList<ECommerce>> PrefixQuery(string customerFullName)
        {
            var result = await _repository.PrefixQueryAsync(customerFullName); return result;
        }

        public async Task<ImmutableList<ECommerce>> RangeQuery(double fromPrice, double toPrice)
        {
            var result = await _repository.RangeQueryAsync(fromPrice, toPrice); return result;
        }

        public Task<ImmutableList<ECommerce>> PriceRangeQueryByDate(double fromPrice, double toPrice, DateTime fromDate, DateTime toDate)
        {
            return _repository.PriceRangeQueryByDateAsync(fromPrice, toPrice, fromDate, toDate);
        }

        public async Task<ImmutableList<ECommerce>> DateRangeQuery(DateTime fromDate, DateTime toDate)
        {
            return await _repository.DateRangeQueryAsync(fromDate, toDate);
        }

        public async Task<ImmutableList<ECommerce>> MatchAllQuery()
        {
            return await _repository.MatchAllQueryAsync();
        }

        public async Task<ImmutableList<ECommerce>> PaginationQuery(int page, int pageSize)
        {
            return await _repository.PaginationQueryAsync(page, pageSize);
        }

        public async Task<ImmutableList<ECommerce>> WildCardQuery(string customerFullName)
        {
            return await _repository.WildCardQueryAsync(customerFullName);
        }

        public async Task<ImmutableList<ECommerce>> FuzzyQuery(string customerFirstName)
        {
            return await _repository.FuzzyQueryAsync(customerFirstName);
        }

        public async Task<ImmutableList<ECommerce>> MatchQueryFullText(string categoryName)
        {
            return await _repository.MatchQueryFullTextAsync(categoryName);
        }

        public async Task<ImmutableList<ECommerce>> MultiMatchQueryFullText(string name)
        {
            return await _repository.MultiMatchQueryFullTextAsync(name);
        }

        public async Task<ImmutableList<ECommerce>> MatchBoolPrefixQueryFullText(string customerFullName)
        {
            return await _repository.MatchBoolPrefixQueryFullTextAsync(customerFullName);
        }

        public async Task<ImmutableList<ECommerce>> MatchPhraseQueryFullText(string customerFullName)
        {
            return await _repository.MatchPhraseQueryFullTextAsync(customerFullName);
        }

        public Task<ImmutableList<ECommerce>> CompoundQuery(string cityName, double taxfulTotalPrice, string category, string manufacturer)
        {
            return _repository.CompoundQueryAsync(cityName, taxfulTotalPrice, category, manufacturer);
        }

        public Task<ImmutableList<ECommerce>> CompoundFullTextAndTermQuery(string customerFullName)
        {
           return _repository.CompoundFullTextAndTermQueryAsync(customerFullName);
        }



		#endregion

		#region WEB-UI

		public async Task<(List<ECommerceDto>, long totalCount, long pageLinkCount)> SearchAsync(ECommerceSearchDto filter, int page, int pageSize)
		{
			var (eCommerceList, totalCount) = await _repository.SearchAsync(filter, page, pageSize);

            var pageLinkCountCalculate = totalCount % pageSize;

            long pageLinkCount = 0;

            if (pageLinkCount ==0)
            {
                pageLinkCount = totalCount / pageSize;
            }
            else
            {
                pageLinkCount =(totalCount / pageSize) + 1;
            }

            var eCommerceListDto = eCommerceList.Select(x=> new ECommerceDto()
            {
                Category = String.Join(",", x.Category),
                CustomerFirstName = x.CustomerFirstName,
                CustomerLastName = x.CustomerLastName,
                CustomerFullName = x.CustomerFullName,
                OrderDate=x.OrderDate.ToShortDateString(),
                Gender= x.Gender.ToLower(),
                Id=x.Id,
                OrderId=x.OrderId,
                TaxfulTotalPrice=x.TaxfulTotalPrice,

            }).ToList();

            return (eCommerceListDto, totalCount, pageLinkCount);
		}


		#endregion
	}

}
