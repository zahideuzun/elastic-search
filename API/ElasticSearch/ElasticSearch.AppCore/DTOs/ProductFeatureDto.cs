using ElasticSearch.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.DTOs
{
    public record ProductFeatureDto(int Width, int Height, EColor Color)
    {
    }
}
