using ElasticSearch.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.DTOs.ProductDTOs
{
    public record ProductFeatureDto(int Width, int Height, string Color)
    {
    }
}
