using System.ComponentModel.DataAnnotations;

namespace ElasticSearch.AppCore.DTOs.BlogDTOs
{
	public class BlogCreateDto
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        public string? Tags { get; set; } 

       
    }
}
