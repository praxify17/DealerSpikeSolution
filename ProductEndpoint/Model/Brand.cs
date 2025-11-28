namespace ProductEndpoint.Model
{
	public class Brand
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Logo { get; set; }
		public string Industry { get; set; }
		public string Slug { get; set; }
		public int Sequence { get; set; }
		public bool HasInStockUnits { get; set; }

		public ICollection<Product> Products { get; set; }
	}

}
