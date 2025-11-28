using Microsoft.EntityFrameworkCore;
using ProductEndpoint.Model;

namespace ProductEndpoint.Data
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options)
			: base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<ProductSubType> ProductSubTypes { get; set; }
		public DbSet<MediaItem> MediaItems { get; set; }
		public DbSet<Pricing> Pricings { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<ProductAttributes> ProductAttributes { get; set; }
	}
}
