using ProductEndpoint.Model;

namespace ProductEndpoint.Data
{
	public static class DumyData
	{
		public static void Seed(ProductDbContext context)
		{
			if (!context.Products.Any())
			{
				context.Products.AddRange(
					new Product { Name = "Laptop", Price = 55000 },
					new Product { Name = "Keyboard", Price = 1200 },
					new Product { Name = "Mouse", Price = 800 }
				);
				context.SaveChanges();
			}
		}
	}
}