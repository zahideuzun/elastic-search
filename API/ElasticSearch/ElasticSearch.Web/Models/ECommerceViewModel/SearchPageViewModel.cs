using ElasticSearch.AppCore.DTOs.ECommerceDTOs;

namespace ElasticSearch.WEB.Models.ECommerceViewModel
{
	public class SearchPageViewModel
	{
        public long TotalCount { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public long PageLinkCount { get; set; }
        public List<ECommerceDto> ECommerceList { get; set; }
        public ECommerceSearchDto SearchViewModel { get; set; }

        public string CreatePageUrl(HttpRequest request, int page, int pageSize )
        {
            var currentUrl = new Uri($"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}").AbsoluteUri;
            if (currentUrl.Contains("page", StringComparison.OrdinalIgnoreCase))
            {
                currentUrl = currentUrl.Replace($"Page={Page}", $"Page={page}", StringComparison.OrdinalIgnoreCase);
				currentUrl = currentUrl.Replace($"PageSize={PageSize}", $"PageSize={pageSize}", StringComparison.OrdinalIgnoreCase);
			}
            else
            {
                currentUrl = $"{currentUrl}?Page={page}";
				currentUrl = $"{currentUrl}?PageSize={pageSize}";
			}

            return currentUrl;
        }

    }
}
