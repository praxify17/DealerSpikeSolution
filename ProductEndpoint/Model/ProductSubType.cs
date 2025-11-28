namespace ProductEndpoint.Model
{
	public class ProductSubType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Year { get; set; }
		public string Slug { get; set; }
		public int Sequence { get; set; }
		public bool HasInStockUnits { get; set; }

		// Foreign key
		public int ProductTypeId { get; set; }
		public ProductType ProductType { get; set; }
	}

}