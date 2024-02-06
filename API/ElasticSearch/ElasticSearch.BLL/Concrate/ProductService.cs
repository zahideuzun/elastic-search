using ElasticSearch.AppCore.DTOs;
using ElasticSearch.BLL.Abstract;
using ElasticSearch.DAL.Repositories.Infrastructor;
using System.Net;


namespace ElasticSearch.BLL.Concrate
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<ProductDto>> SaveAsync(ProductCreateDto request)
        {
            var responseProduct = await _productRepository.SaveAsync(request.CreateProduct());
            if (responseProduct == null)
            {
                return ResponseDto<ProductDto>.Fail(new List<string> { "hata" }, HttpStatusCode.InternalServerError);
            }

            return ResponseDto<ProductDto>.Success(responseProduct.CreateDto(), HttpStatusCode.Created);
        }
    }
}
