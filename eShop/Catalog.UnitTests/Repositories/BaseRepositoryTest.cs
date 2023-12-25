
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.UnitTests;

public class BaseRepositoryTest
{
    private IBaseRepository<CatalogItem> _baseRepository;
    
    
    public BaseRepositoryTest()
    {
        _baseRepository = IBaseRepositoryMock.GetMock();
    }

    [Fact]
    public async Task Test()
    {
        var x = _baseRepository.FindByCondition(c => c.Price > 15).ToList();

    }
}