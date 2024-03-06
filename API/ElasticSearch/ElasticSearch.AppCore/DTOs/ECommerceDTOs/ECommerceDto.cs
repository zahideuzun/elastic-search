namespace ElasticSearch.AppCore.DTOs.ECommerceDTOs
{
	public class ECommerceDto
	{
		public string Id { get; set; } = null!;
		public string CustomerFirstName { get; set; } = null!;
		public string CustomerLastName { get; set; } = null!;
		public string CustomerFullName { get; set; } = null!;

		public string Category { get; set; } = null!;

		public double TaxfulTotalPrice { get; set; }

		public string Gender { get; set; } = null!;

        public int OrderId { get; set; }
        public string OrderDate { get; set; } = null!;

	}
}
