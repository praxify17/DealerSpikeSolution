namespace ProductEndpoint.Model
{
	public class Product
	{
		public int Id { get; set; }
		public Guid IdGuid { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int Year { get; set; }
		public bool IsInStock { get; set; }
		public string Slug { get; set; }
		public bool IsMapProtectedByHonda { get; set; }

		public Brand Brand { get; set; }
		public ProductType Type { get; set; }

		public List<MediaItem> Media { get; set; }
		public Pricing Pricing { get; set; }
		public Location Location { get; set; }
		public ProductAttributes Attributes { get; set; }
		public string ImageUrl { get; internal set; }
		public int BrandId { get; internal set; }
		public int ProductTypeId { get; internal set; }
	}

}
