using Catalog.Host.Repositories.Interfaces;

namespace Catalog.UnitTests;

public static class IBaseRepositoryMock
{
    public static IBaseRepository<CatalogItem> GetMock()
    {
        var items = GetCatalogItems();
        var dbContextMock = AppDbContextMock.GetMock<CatalogItem, AppDbContext>(items, x => x.CatalogItems);
        return new BaseRepository<CatalogItem>(dbContextMock);
    }

    private static  List<CatalogItem> GetCatalogItems()
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
}