using ElasticSearch.API.Controllers.Base;
using ElasticSearch.AppCore.DTOs.ProductDTOs;
using ElasticSearch.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch.API.Controllers
{

	public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDto request)
        {
            return CreateActionResult(await _productService.SaveAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto request)
        {
            return CreateActionResult(await _productService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return CreateActionResult(await _productService.DeleteAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return CreateActionResult(await _productService.GetByIdAsync(id));
        }
    }
}
