using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces.Interfaces;

namespace Catalog.Host.Services.Interfaces;

public class BrandService : IBrandService
{
    private readonly IBaseRepository<Brand> _baseRepository;
    private readonly IMapper _mapper;
    
    public BrandService(IMapper mapper, IBaseRepository<Brand> baseRepository) 
    {
        _mapper = mapper;
        _baseRepository = baseRepository;
    }

    public async Task<Brand> CreateBrand(BrandDto brandDto)
    {
        if (brandDto == null)
        {
            throw new ArgumentNullException(nameof(brandDto), "BrandDto cannot be null");
        }
        
        var brand = _mapper.Map<BrandDto, Brand>(brandDto);
        
        if (brand == null)
        {
            throw new InvalidOperationException("Mapping from BrandDto to Brand failed");
        }
        try
        {
            await _baseRepository.Create(brand);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to create brand", ex);
        }

        return brand;
    }

    public async Task<Brand> UpdateBrand(int id, BrandDto brandDto)
    {
        if (brandDto == null)
        {
            throw new ArgumentNullException(nameof(brandDto), "BrandDto cannot be null");
        }

        var existingBrand = await _baseRepository.FindById(brandDto.Id);
        if (existingBrand == null)
        {
            throw new InvalidOperationException($"Brand with ID {brandDto.Id} not found");
        }


        _mapper.Map(brandDto, existingBrand);


        try
        {
            await _baseRepository.Update(existingBrand);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to update brand", ex);
        }

        return existingBrand;
    }

    public async Task<Brand> DaleteBrand(int Id)
    {
        var brand = await GetBrandById(Id);

        if (brand == null)
        {
            throw new InvalidOperationException($"Brand with ID {Id} not found");
        }

        try
        {
            await _baseRepository.Delete(brand);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to delete brand", ex);
        }

        return brand;
    }

    public IQueryable<Brand> GetBrands()
    {
        return _baseRepository.FindAll();
    }

    public async Task<Brand?> GetBrandById(int id)
    {
        
        return await _baseRepository.FindById(id);
    }
}