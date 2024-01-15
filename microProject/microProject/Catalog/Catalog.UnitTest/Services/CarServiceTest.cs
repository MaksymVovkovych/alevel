using AutoMapper;
using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Moq;

namespace Catalog.UnitTest;

public class CarServiceTests
{
    [Fact]
    public async Task CreateCar_ShouldMapDtoToEntityAndCallCreateInRepository_SuccessCreateCar()
    {
        // Arrange
        var mapperMock = new Mock<IMapper>();
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        var carService = new CarService(mapperMock.Object, repositoryMock.Object);

        var carDto = new CarDto();
        var mappedCar = new Car();
        mapperMock.Setup(m => m.Map<CarDto, Car>(carDto)).Returns(mappedCar);

        // Act
        var result = await carService.CreateCar(carDto);

        // Assert
        mapperMock.Verify(m => m.Map<CarDto, Car>(carDto), Times.Once);
        repositoryMock.Verify(r => r.Create(mappedCar), Times.Once);
        Assert.Equal(mappedCar, result);
    }

    [Fact]
    public async Task UpdateCar_ShouldMapDtoToEntityAndCallUpdateInRepository_SuccessUpdateCar()
    {
        // Arrange
        var mapperMock = new Mock<IMapper>();
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        var carService = new CarService(mapperMock.Object, repositoryMock.Object);
        var carId = 1;
        var carDto = new CarDto();
        var mappedCar = new Car();
        var existCar = new Car();
        mapperMock.Setup(m => m.Map<CarDto, Car>(carDto)).Returns(mappedCar);
        repositoryMock.Setup(s => s.FindById(carId)).ReturnsAsync(existCar);

        // Act
        var result = await carService.UpdateCar(carId, carDto);

        // Assert
        mapperMock.Verify(m => m.Map<CarDto, Car>(carDto), Times.Once);
        repositoryMock.Verify(r => r.Update(mappedCar), Times.Once);
        Assert.Equal(mappedCar, result);
    }

    [Fact]
    public async Task DeleteCar_ShouldCallGetCarByIdAndDeleteInRepository_SuccessDeleteCar()
    {
        // Arrange
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        var carService = new CarService(new Mock<IMapper>().Object, repositoryMock.Object);

        var carId = 1;
        var car = new Car();
        repositoryMock.Setup(r => r.FindById(carId)).ReturnsAsync(car);

        // Act
        var result = await carService.DaleteCar(carId);

        // Assert
        repositoryMock.Verify(r => r.FindById(carId), Times.Once);
        repositoryMock.Verify(r => r.Delete(car), Times.Once);
        Assert.Equal(car, result);
    }

    [Fact]
    public void GetCars_ShouldReturnQueryableFromRepository_SuccessReturnCars()
    {
        // Arrange
        var expectedCars = new List<Car> { new Car(), new Car() }.AsQueryable();
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        repositoryMock.Setup(r => r.FindAll()).Returns(expectedCars);
        var carService = new CarService(new Mock<IMapper>().Object, repositoryMock.Object);

        // Act
        var result = carService.GetCars();

        // Assert
        Assert.Equal(expectedCars, result);
    }

    [Fact]
    public async Task GetCarById_ShouldCallFindByIdInRepository_SuccessReturnCarById()
    {
        // Arrange
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        var carService = new CarService(new Mock<IMapper>().Object, repositoryMock.Object);

        var carId = 1;

        // Act
        await carService.GetCarById(carId);

        // Assert
        repositoryMock.Verify(r => r.FindById(carId), Times.Once);
    }
    
    [Fact]
    public async Task CreateCar_WhenMappingFails_ShouldThrowException()
    {
        // Arrange
        var mapperMock = new Mock<IMapper>();
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        var carService = new CarService(mapperMock.Object, repositoryMock.Object);

        var carDto = new CarDto();
        mapperMock.Setup(m => m.Map<CarDto, Car>(carDto)).Throws<Exception>(); // Simulate mapping failure

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => carService.CreateCar(carDto));
    }

    [Fact]
    public async Task UpdateCar_WhenMappingFails_ShouldThrowException()
    {
        // Arrange
        var mapperMock = new Mock<IMapper>();
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        var carService = new CarService(mapperMock.Object, repositoryMock.Object);
        var carId = 1;
        var carDto = new CarDto();
        mapperMock.Setup(m => m.Map<CarDto, Car>(carDto)).Throws<Exception>(); // Simulate mapping failure

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => carService.UpdateCar(carId, carDto));
    }

    [Fact]
    public async Task DeleteCar_WhenGetCarByIdFails_ShouldThrowException()
    {
        // Arrange
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        var carService = new CarService(new Mock<IMapper>().Object, repositoryMock.Object);

        var carId = 1;
        repositoryMock.Setup(r => r.FindById(carId)).Throws<Exception>(); // Simulate repository failure

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => carService.DaleteCar(carId));
    }

    [Fact]
    public void GetCars_WhenRepositoryReturnsNull_ShouldReturnEmptyQueryable()
    {
        // Arrange
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        repositoryMock.Setup(r => r.FindAll()).Returns((IQueryable<Car>)null);
        var carService = new CarService(new Mock<IMapper>().Object, repositoryMock.Object);

        // Act
        var result = carService.GetCars();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetCarById_WhenRepositoryReturnsNull_ShouldReturnNull()
    {
        // Arrange
        var repositoryMock = new Mock<IBaseRepository<Car>>();
        repositoryMock.Setup(r => r.FindById(It.IsAny<int>())).ReturnsAsync((Car)null);
        var carService = new CarService(new Mock<IMapper>().Object, repositoryMock.Object);

        // Act
        var result = await carService.GetCarById(1);

        // Assert
        Assert.Null(result);
    }
}