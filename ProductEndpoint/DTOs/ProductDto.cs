namespace ProductEndpoint.DTOs
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public int Year { get; set; }
		public bool IsInStock { get; set; }
		public string Slug { get; set; }
		public string BrandName { get; set; }
		public string ProductTypeName { get; set; }
		public decimal Price { get; set; }
	}
}
