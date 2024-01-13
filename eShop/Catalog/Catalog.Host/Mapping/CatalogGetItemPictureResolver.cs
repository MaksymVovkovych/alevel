using AutoMapper;
using Catalog.Host.Configurations;
using Catalog.Host.Data.Entity;
using Catalog.Host.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Catalog.Host.Mapping;

public class CatalogGetItemPictureResolver : IMemberValueResolver<CatalogItem, CatalogGetItemDto, string, object>
{
    private readonly CatalogConfig _config;

    public CatalogGetItemPictureResolver(IOptionsSnapshot<CatalogConfig> config)
    {
        _config = config.Value;
    }

    public object Resolve(CatalogItem source, CatalogGetItemDto destination, string sourceMember, object destMember, ResolutionContext context)
    {
        return $"{_config.Host}/{_config.ImgUrl}/{sourceMember}";
        //return $"/{_config.ImgUrl}/{sourceMember}";
    }
}