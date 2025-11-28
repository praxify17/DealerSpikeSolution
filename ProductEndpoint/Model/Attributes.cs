namespace ProductEndpoint.Model
{
	public class ProductAttributes
	{
		public int Id { get; set; }
		public string StockNumber { get; set; }
		public string VIN { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
	}

}
