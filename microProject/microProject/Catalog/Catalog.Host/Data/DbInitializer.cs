using Catalog.Host.Data.Entity;

namespace Catalog.Host.Data;

public class DbInitializer
{
    
    public async static  Task Initialize(AppDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Brands.Any())
            {
                await context.AddRangeAsync(GetPreconfiguratedCatalogBrands());

                await context.SaveChangesAsync();
            }
            if (!context.Cars.Any())
            {
                await context.AddRangeAsync(GetPreconfiguratedCars());
                
                await context.SaveChangesAsync();
            }
        }


        private static  IEnumerable<Car> GetPreconfiguratedCars()
        {
            return new []
            {
                new Car(){BrandId = 1, Color = "white", Year = 2000},
                new Car(){BrandId = 1, Color = "black", Year = 2020},
                new Car(){BrandId = 2, Color = "white", Year = 2004},
                new Car(){BrandId = 2, Color = "blue", Year = 2600},
                new Car(){BrandId = 3, Color = "gray", Year = 2050},
                new Car(){BrandId = 3, Color = "black", Year = 2001},
            };
        }

        private static  IEnumerable<Brand> GetPreconfiguratedCatalogBrands()
        {
            return new[]
            {
                new Brand() { Name = "BMW" },
                new Brand() { Name = "Mercedes" },
                new Brand() { Name = "Audi" }
            };
        }
}
