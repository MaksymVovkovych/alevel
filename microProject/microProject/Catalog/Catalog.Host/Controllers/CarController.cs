using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;
using Catalog.Host.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;


[Authorize(Policy = "AuthenteficatedUser")]
[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private  readonly ICarService _carService;
    
    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public  ActionResult<IQueryable<Car>> GetCars()
    {
        return Ok(_carService.GetCars());
    }
    
    [HttpGet("ById")]
    public async Task<Car> GetByIdAsync(int id)
    {
        var car = await _carService.GetCarById(id);
        return car;
    }

    [HttpPost]
    public async Task<Car> PostCarAsync(CarDto carDto)
    {
        return await _carService.CreateCar(carDto);
        
    }
    
    [HttpPut]
    public async Task<Car> UpdateCarAsync(int id, CarDto carDto)
    {
        return await _carService.UpdateCar(id, carDto);
    }
    
    [HttpDelete]
    public async Task<Car> DeleteCarAsync(int id)
    {
        return await _carService.DaleteCar(id);
    }
}