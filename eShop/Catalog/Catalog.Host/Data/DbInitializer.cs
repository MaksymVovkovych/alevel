namespace Catalog.Host.Data.Entity;

public static class DbInitializer
{
    public async static  Task Initialize(AppDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogBrands.Any())
        {
            await context.AddRangeAsync(GetPreconfiguratedCatalogBrands());

            await context.SaveChangesAsync();
        }
        if (!context.CatalogItems.Any())
        {
            await context.AddRangeAsync(GetPreconfiguratedCatalogItems());
            
            await context.SaveChangesAsync();
        }
        if (!context.CatalogTypes.Any())
        {
            await context.AddRangeAsync(GetPreconfiguratedCatalogTypes());
            
            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogType> GetPreconfiguratedCatalogTypes()
    {
        return new List<CatalogType>()
        {
            new CatalogType() { Id = Guid.NewGuid(), Type = "Mug" },
            new CatalogType() { Id = Guid.NewGuid(), Type = "T-Shirt" },
            new CatalogType() { Id = Guid.NewGuid(), Type = "Sheet" },
            new CatalogType() { Id = Guid.NewGuid(), Type = "USB Memory Stick" }
        };
    }

    private static  IEnumerable<CatalogItem> GetPreconfiguratedCatalogItems()
    {
        return new List<CatalogItem>()
        {
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = ".NET Bot Black Hoodie",
                Name = ".NET Bot Black Hoodie", Price = 19.5M, PictureFileName = "1.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = ".NET Black & White Mug",
                Name = ".NET Black & White Mug", Price = 8.50M, PictureFileName = "2.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = "Prism White T-Shirt",
                Name = "Prism White T-Shirt", Price = 12, PictureFileName = "3.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = ".NET Foundation T-shirt",
                Name = ".NET Foundation T-shirt", Price = 12, PictureFileName = "4.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = "Roslyn Red Sheet",
                Name = "Roslyn Red Sheet", Price = 8.5M, PictureFileName = "5.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = ".NET Blue Hoodie",
                Name = ".NET Blue Hoodie", Price = 12, PictureFileName = "6.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = "Roslyn Red T-Shirt",
                Name = "Roslyn Red T-Shirt", Price = 12, PictureFileName = "7.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = "Kudu Purple Hoodie",
                Name = "Kudu Purple Hoodie", Price = 8.5M, PictureFileName = "8.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = "Cup<T> White Mug",
                Name = "Cup<T> White Mug", Price = 12, PictureFileName = "9.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = ".NET Foundation Sheet",
                Name = ".NET Foundation Sheet", Price = 12, PictureFileName = "10.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = "Cup<T> Sheet",
                Name = "Cup<T> Sheet", Price = 8.5M, PictureFileName = "11.png"
            },
            new CatalogItem
            {
                Id = Guid.NewGuid(), AvailableStock = 100, Description = "Prism White TShirt",
                Name = "Prism White TShirt", Price = 12, PictureFileName = "12.png"
            }
        };
    }

    private static  IEnumerable<CatalogBrand> GetPreconfiguratedCatalogBrands()
    {
        return new List<CatalogBrand>()
        {
            new CatalogBrand() { Id = Guid.NewGuid(), Brand = "Azure" },
            new CatalogBrand() { Id = Guid.NewGuid(), Brand = ".NET" },
            new CatalogBrand() { Id = Guid.NewGuid(), Brand = "Visual Studio" },
            new CatalogBrand() { Id = Guid.NewGuid(), Brand = "SQL Server" },
            new CatalogBrand() { Id = Guid.NewGuid(), Brand = "Other" }
        };
    }
}