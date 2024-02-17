using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElasticSearch.WEB.Models.ECommerceViewModel
{
	public class ECommerceSearchViewModel
	{
        [DisplayName("Category")]
        public string? Category { get; set; }

		[DisplayName("Gender")]
		public string? Gender { get; set; }

		[DisplayName("Order Start Date")]
		[DataType(DataType.Date)]
		public DateTime? OrderDateStart { get; set; }

		[DisplayName("Order End Date")]
		[DataType(DataType.Date)]
		public DateTime? OrderDateEnd { get; set; }

		[DisplayName("Customer Full Name")]
		public string? CustomerFullName { get; set; }
    }
}
