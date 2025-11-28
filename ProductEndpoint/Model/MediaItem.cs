namespace ProductEndpoint.Model
{
	public class MediaItem
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public int Sequence { get; set; }
		public bool IsPrimary { get; set; }
		public bool IsImage { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
	}

}
