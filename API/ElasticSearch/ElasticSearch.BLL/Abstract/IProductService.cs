using ElasticSearch.AppCore.DTOs;
using ElasticSearch.DAL.Repositories.Infrastructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.BLL.Abstract
{
    public interface IProductService
    {
        public Task<ResponseDto<ProductDto>> SaveAsync(ProductCreateDto request);
    }
}
