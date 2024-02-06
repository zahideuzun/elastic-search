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
    public record ProductCreateDto(string Name, decimal Price, int Stock, ProductFeatureDto Feature)
    {
        public Product CreateProduct() 
        { 
            return new Product 
            {   Name = Name, 
                Price = Price,
                Stock = Stock, 
                Feature= new ProductFeature()
                {
                    Width = Feature.Width,
                    Height = Feature.Height,
                    Color = Feature.Color,
                }
            
            }; 
        }
    }
}
