namespace ElasticSearch.AppCore.DTOs.ProductDTOs
{
	public record ProductUpdateDto(string Id, string Name, decimal Price, int Stock, ProductFeatureDto Feature)
    {

    }
}
