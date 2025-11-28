using ProductEndpoint.Data;
using ProductEndpoint.Model;
using System;
using System.Linq;

public static class DummyData
{
	public static void Seed(ProductDbContext context)
	{
		// ==========================
		// 1️⃣ Seed Brands
		// ==========================
		if (!context.Brands.Any())
		{
			context.Brands.AddRange(
				new Brand
				{
					Name = "Arctic Cat",
					Logo = "https://cdn.example.com/arcticcat.png",
					Industry = "Powersports",
					Slug = "arctic-cat",
					Sequence = 1,
					HasInStockUnits = true
				},
				new Brand
				{
					Name = "Yamaha",
					Logo = "https://cdn.example.com/yamaha.png",
					Industry = "Powersports",
					Slug = "yamaha",
					Sequence = 2,
					HasInStockUnits = true
				}
			);
			context.SaveChanges();
		}
		var brand = context.Brands.First();

		// ==========================
		// 2️⃣ Seed ProductTypes
		// ==========================
		if (!context.ProductTypes.Any())
		{
			context.ProductTypes.AddRange(
				new ProductType
				{
					Name = "ATV",
					Slug = "atv",
					Sequence = 1000,
					HasInStockUnits = true
				},
				new ProductType
				{
					Name = "Side-by-Side",
					Slug = "side-by-side",
					Sequence = 1000,
					HasInStockUnits = true
				}
			);
			context.SaveChanges();
		}
		var atvType = context.ProductTypes.First(pt => pt.Name == "ATV");

		// ==========================
		// 3️⃣ Seed ProductSubTypes (one-to-many)
		// ==========================
		if (!context.ProductSubTypes.Any())
		{
			context.ProductSubTypes.AddRange(
				new ProductSubType
				{
					Name = "Alterra",
					Year = 2024,
					Slug = "alterra",
					Sequence = 1000,
					HasInStockUnits = true,
					ProductTypeId = atvType.Id
				}
			);
			context.SaveChanges();
		}
		var alterraSubType = context.ProductSubTypes.First();

		// ==========================
		// 4️⃣ Seed Products
		// ==========================
		if (!context.Products.Any())
		{
			var product = new Product
			{
				Name = "Wildcat XX",
				Slug = "wildcat-xx",
				IdGuid = Guid.NewGuid(),
				Image = "https://cdn.example.com/wildcatxx.jpg",
				ImageUrl = "https://cdn.example.com/wildcatxx.jpg",  // NOT NULL
				Year = 2024,
				IsInStock = true,
				IsMapProtectedByHonda = false,
				BrandId = brand.Id,
				ProductTypeId = atvType.Id,
				Type = atvType,
				Attributes = new ProductAttributes
				{
					StockNumber = "Stock 001",
					VIN = "VIN001"
				}
			};

			context.Products.Add(product);
			context.SaveChanges();

			// ==========================
			// 5️⃣ Seed Pricing
			// ==========================
			context.Pricings.Add(new Pricing
			{
				ProductId = product.Id,
				Price = 19999,
				Label = "Web Price",          // NOT NULL
				IsCallForPrice = false,
				IsSold = false
			});

			// ==========================
			// 6️⃣ Seed Location
			// ==========================
			context.Locations.Add(new Location
			{
				ProductId = product.Id,
				Name = "ARI",
				Address = "CW 16",
				City = "Duluth",
				Region = "AL",
				PostalCode = "40303",
				Country = "United States",
				Phone = "7829580385"
			});

			// ==========================
			// 7️⃣ Seed Media
			// ==========================
			context.MediaItems.Add(new MediaItem
			{
				ProductId = product.Id,
				Url = "https://cdn.example.com/wildcatxx.jpg",
				Sequence = 0,
				IsPrimary = true,
				IsImage = true
			});

			context.SaveChanges();
		}
	}
}
