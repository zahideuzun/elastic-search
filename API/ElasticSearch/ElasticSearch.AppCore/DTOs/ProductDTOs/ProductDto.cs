namespace ElasticSearch.AppCore.DTOs.ProductDTOs
{
	public record ProductDto(string Id, string Name, decimal Price, int Stock, ProductFeatureDto? Feature)
    {

    }
}
