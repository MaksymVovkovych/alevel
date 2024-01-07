
namespace Catalog.UnitTests;

public class BaseRepositoryTest
{

    private IBaseRepository<CatalogItem> _baseRepository;

    public BaseRepositoryTest()
    {
        _baseRepository = IBaseRepositoryMock.GetMock();
    }
    
    CatalogItem existingItem = new CatalogItem
    {
        Id = Guid.NewGuid(), AvailableStock = 100, Description = ".NET Foundation Sheet",
        Name = ".NET Foundation Sheet", Price = 12, PictureFileName = "10.png"
    };

    private int expected = 1;
    
    [Fact]
    public async Task FindAll_ReturnsCatalogItems()
    {
        var lasData = _baseRepository.FindAll();
        
        
        Assert.NotNull(lasData);
    }

    [Fact]
    public void FindByCondition_ReturnIQuerableCatalogItems()
    {
        var item =  _baseRepository.FindByCondition(x => x.Price > 15).ToList();
        
        
        Assert.NotNull(item);
        
    }
    
    [Fact]
    public async Task Create_RerurnSuccess()
    {
        
        var result = await _baseRepository.Create(existingItem);
        
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task Update_ReturnsIntSuccess()
    {
        var updateItem = new CatalogItem()
        {
            Id = existingItem.Id, Description = "UpdateDescription", AvailableStock = 100,
            PictureFileName = "updateFileName.png", Name = "Kotlin", Price = 200
        };
        await _baseRepository.Create(existingItem);

        
        var result = await _baseRepository.Update(updateItem);
        
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public async Task Delete_ReturnsIntSuccess()
    {
        await _baseRepository.Create(existingItem);

        
        var result = await _baseRepository.Delete(existingItem);
        
        
        Assert.Equal(expected, result);
    }
    
}