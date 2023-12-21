using AutoMapper;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.DTOs;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItemDto,CatalogItem>();
        CreateMap<CatalogBrandDto, CatalogBrand>();
        CreateMap<CatalogTypeDto, CatalogType>();
        CreateMap<CatalogItem,CatalogItemDto>();
        CreateMap<CatalogBrand, CatalogBrandDto>();
        CreateMap<CatalogType, CatalogTypeDto>();
    }
}