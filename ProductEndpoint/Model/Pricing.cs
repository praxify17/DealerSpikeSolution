namespace ProductEndpoint.Model
{
	public class Pricing
	{
		public int Id { get; set; }
		public decimal Price { get; set; }
		public string Label { get; set; }
		public bool IsCallForPrice { get; set; }
		public bool IsSold { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
	}

}
