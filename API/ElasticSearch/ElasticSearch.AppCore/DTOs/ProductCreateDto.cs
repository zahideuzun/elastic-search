using ElasticSearch.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.DTOs
{
    //neden record olarak tanimladim? 
    //immutuble oldugu icin bir nesne örnegi olusturdugumda propertyler degistirilemez. ram konusunda da daha avantajlidir.
    //record tanimladigim icin propertylerimi parametre olarak verebiliyorum. c# 9 sonrasi icin.
    public record ProductCreateDto(string Name, decimal Price, int Stock, ProductFeatureDto Feature)
    {
    }
}
