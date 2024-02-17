namespace ElasticSearch.WEB.Models.BlogViewModels
{
	public class BlogViewModel
	{
		public string Id { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string Content { get; set; } = null!;
		public string? Tags { get; set; } 
		public string UserId { get; set; } = null!;
		public string Created { get; set; } = null!;	

		
		//public string TagsDisplay => Tags != null ? String.Join(", ", Tags) : string.Empty;
		//public string CreatedDisplay => DateTime.TryParse(Created, out DateTime createdDate)
		//								? createdDate.ToShortDateString()
		//								: Created;
	}

}
