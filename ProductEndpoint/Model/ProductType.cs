namespace ProductEndpoint.Model
{
	public class ProductType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public int Sequence { get; set; }
		public bool HasInStockUnits { get; set; }

		// One ProductType can have many SubTypes
		public List<ProductSubType> SubTypes { get; set; } = new();
	}

}
