using AutoMapper;
using ElasticSearch.AppCore.DTOs.BlogDTOs;
using ElasticSearch.AppCore.Entities.Blog;
using ElasticSearch.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch.WEB.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Save()
        {
            return View(new BlogCreateDto());
        }

		[HttpGet]
		public async Task<IActionResult> Search()
		{
			var blogList = await _blogService.Search(string.Empty);
			return View(blogList);
		}

		[HttpPost]
		public async Task<IActionResult> Search(string searchText)
		{
            ViewBag.SearchText = searchText;
            var blogList = await _blogService.Search(searchText);
            
			return View(blogList);
		}

		[HttpPost]
        public async Task<IActionResult> Save(BlogCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", model);
            }

            var savedBlog = await _blogService.Save(model);

            if (savedBlog)
            {
                TempData["result"] = "kayıt başarılı";
                return RedirectToAction("Save");
            }
            else
            {
                TempData["result"] = "kayıt başarısız";
                return View("Save", model);
            }
        }
    }
}
