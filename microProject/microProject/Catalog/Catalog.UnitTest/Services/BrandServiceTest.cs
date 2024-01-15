using AutoMapper;
using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Moq;

namespace Catalog.UnitTest;

public class BrandServiceTest
{

    private readonly Mock<IBaseRepository<Brand>> _baseRepositoryBrandMock;
    private readonly Mock<IMapper> _mapperMock;
    private BrandService _brandService;
    
    public BrandServiceTest()
    {
        _baseRepositoryBrandMock = new Mock<IBaseRepository<Brand>>();
        _mapperMock = new Mock<IMapper>();
    }

    [Fact]
    public async Task CreateBrand_ShouldMapEntityAndCallRepo_ReturnSuccessCreatedBrand()
    {
        _brandService = new BrandService(_mapperMock.Object, _baseRepositoryBrandMock.Object);

        var brandDto = new BrandDto();
        var mappedbrand = new Brand();

        _mapperMock.Setup(s => s.Map<BrandDto, Brand>(brandDto)).Returns(mappedbrand);

        var result = await _brandService.CreateBrand(brandDto);

        _mapperMock.Verify(m => m.Map<BrandDto, Brand>(brandDto), Times.Once);
        _baseRepositoryBrandMock.Verify(r => r.Create(mappedbrand), Times.Once);
        Assert.Equal(mappedbrand, result);
    }

    [Fact]
    public async Task UpdateBrand_ShouldMapEntityAndCallRepo_ReturnSuccessUpdatedBrand()
    {
        _brandService = new BrandService(_mapperMock.Object, _baseRepositoryBrandMock.Object);

        var brandDto = new BrandDto();
        int brandId = 1;
        var mappedbrand = new Brand();

        _mapperMock.Setup(s => s.Map<BrandDto, Brand>(brandDto)).Returns(mappedbrand);

        var result = await _brandService.UpdateBrand(brandId, brandDto);

        _mapperMock.Verify(m => m.Map<BrandDto, Brand>(brandDto), Times.Once);
        _baseRepositoryBrandMock.Verify(r => r.Update(mappedbrand), Times.Once);
        Assert.Equal(mappedbrand, result);
    }

    [Fact]
    public async Task DeleteBrand_ShouldFindEntityAndCallRepo_ReturnSuccessDeletedBrand()
    {
        _brandService = new BrandService(_mapperMock.Object, _baseRepositoryBrandMock.Object);

        var brandId = 1;
        var brand = new Brand();
        _baseRepositoryBrandMock.Setup(s => s.FindById(brandId)).ReturnsAsync(brand);

        var result = await _brandService.DaleteBrand(brandId);
        
        _baseRepositoryBrandMock.Verify(r => r.FindById(brandId), Times.Once);
        _baseRepositoryBrandMock.Verify(r => r.Delete(brand), Times.Once);
        Assert.Equal(brand, result);
    }
    
    [Fact]
    public void GetBrands_ShouldReturnQueryableFromRepository_SuccessReturnBrands()
    {
        // Arrange
        _brandService = new BrandService(_mapperMock.Object, _baseRepositoryBrandMock.Object);
        var expectedBrands = new List<Brand> { new Brand(), new Brand() }.AsQueryable();
        _baseRepositoryBrandMock.Setup(r => r.FindAll()).Returns(expectedBrands);


        // Act
        var result = _brandService.GetBrands();

        // Assert
        Assert.Equal(expectedBrands, result);
    }

    [Fact]
    public async Task GetBrandById_ShouldCallFindByIdInRepository_SuccessReturnBrandById()
    {
        // Arrange
        _brandService = new BrandService(_mapperMock.Object, _baseRepositoryBrandMock.Object);

        var brandId = 1;

        // Act
        await _brandService.GetBrandById(brandId);

        // Assert
        _baseRepositoryBrandMock.Verify(r => r.FindById(brandId), Times.Once);
    }
    
}