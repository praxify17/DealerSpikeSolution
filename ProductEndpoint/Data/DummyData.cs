using ProductEndpoint.Data;
using ProductEndpoint.Model;
using System;
using System.Linq;
using System.Collections.Generic;

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
                    Logo = "https://imgd.aeplcdn.com/664x374/n/cw/ec/1/versions/harleydavidson-iron-883-standard1677237126841.jpg",
                    Industry = "Powersports",
                    Slug = "arctic-cat",
                    Sequence = 1,
                    HasInStockUnits = true
                },
                new Brand
                {
                    Name = "Yamaha",
                    Logo = "https://imgd.aeplcdn.com/664x374/n/z0tmohb_1879705.jpg",
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
        // 4️⃣ Seed Products (ensure all 5 dummy products are present)
        // ==========================
        var imageUrls = new[]
        {
            "https://www.sema.org/sites/default/files/inline-images/sn_0523_Powersports_Trends_03.jpg",
            "https://www.sema.org/sites/default/files/sn_0720_powersports_trends-001.jpg",
            "https://www.skypowersportssanford.com/wp-content/uploads/2025/05/8aac5a8c-574f-444b-8a93-4350f4b18bfb.png",
            "https://www.nai-group.com/wp-content/uploads/2020/08/shutterstock_1420578311-scaled.jpg",
            "https://www.hondapowersports.com/images/atv/2022/talon-1000r/gallery/01.jpg"
        };

        var productNames = new[] { "Wildcat XX", "Kodiak 700", "Grizzly EPS", "Alterra 600", "Talon 1000R" };
        var productSlugs = new[] { "wildcat-xx", "kodiak-700", "grizzly-eps", "alterra-600", "talon-1000r" };
        var productYears = new[] { 2024, 2023, 2022, 2024, 2021 };
        var stockNumbers = new[] { "Stock 001", "Stock 002", "Stock 003", "Stock 004", "Stock 005" };
        var vins = new[] { "VIN001", "VIN002", "VIN003", "VIN004", "VIN005" };
        var pricingData = new[] { 19999, 8999, 10999, 12999, 4999 };

        for (int idx = 0; idx < 5; idx++)
        {
            var existingProduct = context.Products
                .FirstOrDefault(p => p.Name == productNames[idx] && p.Year == productYears[idx] && p.SiteId == 35619);
            if (existingProduct == null)
            {
                var product = new Product
                {
                    Name = productNames[idx],
                    Slug = productSlugs[idx],
                    IdGuid = Guid.NewGuid(),
                    Image = "ATV",
                    ImageUrl = imageUrls[idx],
                    Year = productYears[idx],
                    IsInStock = true,
                    IsMapProtectedByHonda = false,
                    BrandId = brand.Id,
                    ProductTypeId = atvType.Id,
                    Type = atvType,
                    Attributes = new ProductAttributes
                    {
                        StockNumber = stockNumbers[idx],
                        VIN = vins[idx]
                    },
                    SiteId = 35619
                };

                context.Products.Add(product);
                context.SaveChanges();

                context.Pricings.Add(new Pricing
                {
                    ProductId = product.Id,
                    Price = pricingData[idx],
                    Label = "Web Price",
                    IsCallForPrice = false,
                    IsSold = false
                });

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

                context.MediaItems.Add(new MediaItem
                {
                    ProductId = product.Id,
                    Url = imageUrls[idx],
                    Sequence = 0,
                    IsPrimary = true,
                    IsImage = true
                });

                context.SaveChanges();
            }
        }
    }
}
