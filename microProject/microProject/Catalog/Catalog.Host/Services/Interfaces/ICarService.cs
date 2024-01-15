using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;

namespace Catalog.Host.Services.Interfaces.Interfaces;

public interface ICarService
{
    Task<Car> CreateCar(CarDto carDto);
    Task<Car> UpdateCar(int id, CarDto carDto);
    Task<Car> DaleteCar(int id);
    IQueryable<Car> GetCars();
    Task<Car?> GetCarById(int id);
}