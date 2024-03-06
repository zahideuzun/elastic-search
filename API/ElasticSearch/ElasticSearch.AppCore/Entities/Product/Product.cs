using ElasticSearch.AppCore.DTOs;
using Nest;

namespace ElasticSearch.AppCore.Entities.Product.Product
{
    public class Product
    {
        //id response icindeki asil data icinde bulunmuyor. metadata icinde geliyor. ben tüm proplarla beraber gelsin istedigim icin belirtiyorum. es tarafinda primary key olarak tutsun diye. 
        [PropertyName("_id")]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public ProductFeature? Feature { get; set; }

    }
}
