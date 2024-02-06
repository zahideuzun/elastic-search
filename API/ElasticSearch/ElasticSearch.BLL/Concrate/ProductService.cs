using AutoMapper;
using ElasticSearch.AppCore.DTOs;
using ElasticSearch.AppCore.Entities;
using ElasticSearch.BLL.Abstract;
using ElasticSearch.DAL.Repositories.Infrastructor;
using System.Collections.Immutable;
using System.Net;


namespace ElasticSearch.BLL.Concrate
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProductDto>> SaveAsync(ProductCreateDto request)
        {
            var product = _mapper.Map<Product>(request); 
            var responseProduct = await _productRepository.SaveAsync(product);
            if (responseProduct == null)
            {
                return ResponseDto<ProductDto>.Fail(new List<string> { "hata" }, HttpStatusCode.InternalServerError);
            }

            var productDto = _mapper.Map<ProductDto>(responseProduct); 
            return ResponseDto<ProductDto>.Success(productDto, HttpStatusCode.Created);
        }


        public async Task<ResponseDto<List<ProductDto>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            //burada product dto icindeki product feature dto nullable sorunu cikarabilir. eger cikarsa default degerler atayarak cozebilirim!!
            var productDtos = products.Select(x => _mapper.Map<ProductDto>(x)).ToList();

            return ResponseDto<List<ProductDto>>.Success(productDtos, HttpStatusCode.OK);
        }

        public async Task<ResponseDto<ProductDto>> GetByIdAsync(string id)
        {
            var hasProduct = await _productRepository.GetByIdAsync(id);

            if (hasProduct == null) return ResponseDto<ProductDto>.Fail("ürün bulunamadı", HttpStatusCode.NotFound);

            return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(hasProduct), HttpStatusCode.OK);

        }
    }
}
