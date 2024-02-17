using ElasticSearch.BLL.Abstract;
using ElasticSearch.WEB.Models.ECommerceViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch.WEB.Controllers
{
	public class ECommerceController : Controller
	{
		private readonly IECommerceService _service;
        public ECommerceController(IECommerceService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Search([FromQuery] SearchPageViewModel searchPageView)
		{
			var (eCommerceList, totalCount, pageLinkCount) = await _service.SearchAsync(searchPageView.SearchViewModel,searchPageView.Page, searchPageView.PageSize);

			searchPageView.ECommerceList = eCommerceList;
			searchPageView.TotalCount = totalCount;
			searchPageView.PageLinkCount = pageLinkCount;

			return View(searchPageView);
		}
	}
}
