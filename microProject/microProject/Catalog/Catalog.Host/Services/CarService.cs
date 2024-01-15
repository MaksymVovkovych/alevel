using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces.Interfaces;

namespace Catalog.Host.Services.Interfaces;

public class CarService :  ICarService
{
    private readonly IBaseRepository<Car> _baseRepository;
    private readonly IMapper _mapper;
    
    public CarService(IMapper mapper, IBaseRepository<Car> baseRepository) 
    {
        _mapper = mapper;
        _baseRepository = baseRepository;
    }

    public async Task<Car> CreateCar(CarDto carDto)
    {
        if (carDto == null)
        {
            throw new ArgumentNullException(nameof(carDto), "CarDto cannot be null");
        }
        
        var car = _mapper.Map<CarDto, Car>(carDto);
        
        if (car == null)
        {
            throw new InvalidOperationException("Mapping from CarDto to Car failed");
        }
        try
        {
            await _baseRepository.Create(car);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to create car", ex);
        }

        return car;
    }

    public async Task<Car> UpdateCar(int id, CarDto carDto)
    {
        if (carDto == null)
        {
            throw new ArgumentNullException(nameof(carDto), "CarDto cannot be null");
        }

        var existingCar = await _baseRepository.FindById(carDto.Id);
        if (existingCar == null)
        {
            throw new InvalidOperationException($"Car with ID {carDto.Id} not found");
        }
        
        _mapper.Map(carDto, existingCar);
        
        try
        {
            await _baseRepository.Update(existingCar);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to update car", ex);
        }
        
        return existingCar;
    }

    public async Task<Car> DaleteCar(int id)
    {
        var car = await GetCarById(id);

        if (car == null)
        {
            throw new InvalidOperationException($"Car with ID {id} not found");
        }

        try
        {
            await _baseRepository.Delete(car);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to delete car", ex);
        }

        return car;
    }

    public IQueryable<Car> GetCars()
    {
        return _baseRepository.FindAll();
    }

    public async Task<Car?> GetCarById(int id)
    {
        return await _baseRepository.FindById(id);
    }
}