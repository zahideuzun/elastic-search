using ElasticSearch.AppCore.DTOs.ProductDTOs;

namespace ElasticSearch.BLL.Abstract
{
	public interface IProductService
    {
        public Task<ResponseDto<ProductDto>> SaveAsync(ProductCreateDto request);

        public Task<ResponseDto<List<ProductDto>>> GetAllAsync();

        public Task<ResponseDto<ProductDto>> GetByIdAsync(string id);

        public Task<ResponseDto<bool>> UpdateAsync(ProductUpdateDto updateProduct);

        public Task<ResponseDto<bool>> DeleteAsync(string id);
    }
}
