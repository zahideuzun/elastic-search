using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.DTOs.ECommerceDTOs
{
	public class ECommerceSearchDto
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
