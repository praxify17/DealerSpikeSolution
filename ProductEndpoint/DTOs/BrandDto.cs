namespace ProductEndpoint.DTOs
{
	public class BrandDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Logo { get; set; }
		public string Industry { get; set; }
		public string Slug { get; set; }
		public bool HasInStockUnits { get; set; }
	}
}