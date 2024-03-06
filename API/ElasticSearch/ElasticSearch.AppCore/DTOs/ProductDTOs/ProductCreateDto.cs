namespace ElasticSearch.AppCore.DTOs.ProductDTOs
{
	//neden record olarak tanimladim? 
	//immutuble oldugu icin bir nesne örnegi olusturdugumda propertyler degistirilemez. ram konusunda da daha avantajlidir.
	//record tanimladigim icin propertylerimi parametre olarak verebiliyorum. c# 9 sonrasi icin.
	public record ProductCreateDto(string Name, decimal Price, int Stock, ProductFeatureDto Feature)
    {
    }
}
