using Microsoft.EntityFrameworkCore;
using ProductEndpoint.Model;

namespace ProductEndpoint.Data
{
	public class ProductDbContext : DbContext
	{
		public ProductDbContext(DbContextOptions<ProductDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
			modelBuilder.Entity<Product>().Property(p => p.ImageUrl).IsRequired(false);
		}

		public DbSet<Model.Product> Products { get; set; }
	}
}
