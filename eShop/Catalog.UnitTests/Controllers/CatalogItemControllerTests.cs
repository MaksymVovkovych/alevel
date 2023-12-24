using AutoMapper;
using Catalog.Host.Controllers;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.UnitTests.Controllers;

public class CatalogItemControllerTests
{
    private Mock<ICatalogItemRepository> _catalogItemRepositoryMock;
    private readonly Mock<IMapper> _mapper;
    private CatalogItemController _catalogItemController;
    
    
    
    public CatalogItemControllerTests()
    {
        _catalogItemRepositoryMock = new Mock<ICatalogItemRepository>();
        _mapper = new Mock<IMapper>();
        _catalogItemController = new CatalogItemController(_catalogItemRepositoryMock.Object, _mapper.Object);
    }
    
    CatalogItem existingItem = new CatalogItem
    {
        Id = Guid.NewGuid(), AvailableStock = 100, Description = ".NET Foundation Sheet",
        Name = ".NET Foundation Sheet", Price = 12, PictureFileName = "10.png"
    };

    private int expected = 1;
    
    [Fact]
    public async Task PostItem_ValidItem_ReturnsOkResult()
    {
        
        _catalogItemRepositoryMock.Setup(s => s.CreateCatalogItem(existingItem)).ReturnsAsync(expected);
        // Act
        var result = await _catalogItemController.PostItem(existingItem);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(expected, okResult.Value);
    }
    [Fact]
    public async Task PutItem_ExistingItem_ReturnsOkResult()
    {
        // Arrange
        var catalogItemDto = new CatalogItemDto
        {
            Id = existingItem.Id,
            Name = "NameDto", 
            Description = "DescriptDto", 
            PictureFileName = "pictDto.png",
            AvailableStock = 100
        };
        _catalogItemRepositoryMock.Setup(repo => repo.GetItemById(existingItem.Id))
            .ReturnsAsync(existingItem);
        _mapper.Setup(m => m.Map(catalogItemDto, existingItem)).Returns(existingItem);
        _catalogItemRepositoryMock.Setup(r => r.UpdateCatalogItem(existingItem)).ReturnsAsync(expected);

        // Act
        var result = await _catalogItemController.PutItem(catalogItemDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(expected, okResult.Value);
    }
    [Fact]
    public async Task PutItem_NonExistingItem_ReturnsNotFound()
    {
        // Arrange
        var catalogItemDto = new CatalogItemDto
        {
            Id = Guid.NewGuid(),
            Name = "NameDto", 
            Description = "DescriptDto", 
            PictureFileName = "pictDto.png",
            AvailableStock = 100
        };
        _catalogItemRepositoryMock.Setup(repo => repo.GetItemById(existingItem.Id))
            .ReturnsAsync((CatalogItem)null);
        _mapper.Setup(m => m.Map(catalogItemDto, existingItem)).Returns(existingItem);
        _catalogItemRepositoryMock.Setup(r => r.UpdateCatalogItem(existingItem)).ReturnsAsync(expected);

        // Act
        var result = await _catalogItemController.PutItem(catalogItemDto);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task DeleteItem_ExistingItem_ReturnsOkResult()
    {
        _catalogItemRepositoryMock.Setup(repo => repo.GetItemById(existingItem.Id))
            .ReturnsAsync(existingItem);
        _catalogItemRepositoryMock.Setup(r => r.DeleteCatalogItem(existingItem)).ReturnsAsync(expected);

        var result = await _catalogItemController.DeleteItem(existingItem.Id);
        
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(expected, okResult.Value);
        
    }
    [Fact]
    public async Task DeleteItem_NonExistingItem_ReturnsNotFound()
    {
        var nonExistingItem = new CatalogItem();
        var nonExistingItemId = Guid.NewGuid();
        _catalogItemRepositoryMock.Setup(repo => repo.GetItemById(nonExistingItemId))
            .ReturnsAsync((CatalogItem)null);
        _catalogItemRepositoryMock.Setup(r => r.DeleteCatalogItem(nonExistingItem)).ReturnsAsync(expected);

        
        var result = await _catalogItemController.DeleteItem(Guid.NewGuid());
        
        
        Assert.IsType<NotFoundResult>(result.Result);
    }
}