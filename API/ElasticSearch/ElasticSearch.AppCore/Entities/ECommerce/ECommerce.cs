using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.Entities.ECommerceModel
{
    public class ECommerce
    {
        //[JsonPropertyName("_id")]
        //elasticsearch.client library'nin property tanimlama sekli

        [PropertyName("_id")]
        public string Id { get; set; } = null!;

        [PropertyName("customer_first_name")]
        public string CustomerFirstName { get; set; } = null!;

        [PropertyName("customer_last_name")]
        public string CustomerLastName { get; set; } = null!;

        [PropertyName("customer_full_name")]
        public string CustomerFullName { get; set; } = null!;

        [PropertyName("category")]
        public string[] Category { get; set; } = null!;

		[PropertyName("customer_gender")]
		public string Gender { get; set; } = null!;

		[PropertyName("taxful_total_price")]
        public double TaxfulTotalPrice { get; set; }

        [PropertyName("order_id")]
        public int OrderId { get; set; }

        [PropertyName("order_date")]
        public DateTime OrderDate { get; set; }

        [PropertyName("products")]
        public Product[]? Products { get; set; }

    }

    public class Product
    {
        [PropertyName("product_id")]
        public long ProductId { get; set; }

        [PropertyName("product_name")]
        public string? ProductName { get; set; } 

    }

    
}
