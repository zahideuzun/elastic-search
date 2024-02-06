using ElasticSearch.AppCore.DTOs;
using ElasticSearch.AppCore.Entities;
using ElasticSearch.DAL.Repositories.Infrastructor;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.BLL.Abstract
{
    public interface IProductService
    {
        public Task<ResponseDto<ProductDto>> SaveAsync(ProductCreateDto request);

        public Task<ResponseDto<List<ProductDto>>> GetAllAsync();

        public Task<ResponseDto<ProductDto>> GetByIdAsync(string id);
    }
}
