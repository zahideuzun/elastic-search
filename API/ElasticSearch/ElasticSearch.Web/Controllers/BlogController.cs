using AutoMapper;
using ElasticSearch.AppCore.DTOs.BlogDTOs;
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
        public IActionResult Save()
        {
            return View(new BlogCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Save(BlogCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", model);
            }

            var savedBlog = await _blogService.SaveAsync(model);

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
