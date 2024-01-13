using AutoMapper;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogItemPictureResolver, string>(c => c.PictureFileName));
        CreateMap<CatalogBrand, CatalogBrandDto>();
        CreateMap<CatalogType, CatalogTypeDto>();
        CreateMap<CatalogItem, CatalogGetItemDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogGetItemPictureResolver, string>(c => c.PictureFileName));
    }
}