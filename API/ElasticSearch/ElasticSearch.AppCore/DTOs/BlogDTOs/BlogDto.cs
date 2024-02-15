using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.DTOs.BlogDTOs
{
	public class BlogDto
	{
		public string Id { get; set; } = null!;

		public string Title { get; set; } = null!;

		public string Content { get; set; } = null!;

		public string[] Tags { get; set; } = null!;

		public Guid UserId { get; set; }

		public DateTime Created { get; set; }
	}
}
