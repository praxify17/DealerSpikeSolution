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
					new Product
					{
						Name = "PowerSport 3",
						Price = 55000,
						ImageUrl = "https://www.sema.org/sites/default/files/inline-images/sn_0523_Powersports_Trends_03.jpg"
					},
					new Product
					{
						Name = "PowerSport 2",
						Price = 1200,
						ImageUrl = "https://gates.scene7.com/is/image/gates/powersports-top-banner?$Image_Responsive_Preset$&scl=1"
					},
					new Product
					{
						Name = "PowerSport 1",
						Price = 800,
						ImageUrl = "https://www.skypowersportssanford.com/wp-content/uploads/2025/05/8aac5a8c-574f-444b-8a93-4350f4b18bfb.png"
					}
				);

				context.SaveChanges();
			}

		}
	}
}