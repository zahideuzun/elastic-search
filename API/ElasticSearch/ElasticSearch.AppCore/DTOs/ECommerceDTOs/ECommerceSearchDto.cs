using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.DTOs.ECommerceDTOs
{
	public class ECommerceSearchDto
	{
		
		public string? CustomerFullName { get; set; } 

		public string? Category { get; set; }

		public string? Gender { get; set; } 

		public DateTime? OrderDateStart { get; set; }

		public DateTime? OrderDateEnd { get; set; }

	}
}
