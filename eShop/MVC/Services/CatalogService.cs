using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MVC.Models.Enums;
using MVC.Models.Requests;
using MVC.Models.Responses;
using MVC.Services.Interfaces;
using MVC.ViewModels;


namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IHttpClientService _httpClientService;
    private readonly IOptions<AppSettings> _settings;
    public CatalogService(IHttpClientService httpClientService, IOptions<AppSettings> settings)
    {
        _httpClientService = httpClientService;
        _settings = settings;
    }


    public async Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type)
    {
        var filters = new Dictionary<CatalogTypeFilter, int>();

        if (brand.HasValue)
        {
            filters.Add(CatalogTypeFilter.Brand, brand.Value);
        }
        
        if (type.HasValue)
        {
            filters.Add(CatalogTypeFilter.Type, type.Value);
        }
        
        var result = await _httpClientService.SendAsync<Catalog, PaginatedItemsRequest<CatalogTypeFilter>>($"{_settings.Value.CatalogUrl}/items",
            HttpMethod.Post, 
            new PaginatedItemsRequest<CatalogTypeFilter>()
            {
                PageIndex = page,
                PageSize = take,
                Filters = filters
            });

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GetBrands()
    {
        var url = $"{_settings.Value.CatalogUrl}/Brands";
        var response =
            await _httpClientService.SendAsync<PaginatedBrandResponse, object>(url, HttpMethod.Get, null);
        var brands = response.Data;
        return brands.Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Brand });
    }

    public async Task<IEnumerable<SelectListItem>> GetTypes()
    {
        var url = $"{_settings.Value.CatalogUrl}/Types"; // Use the correct endpoint for types
        var response =
            await _httpClientService.SendAsync<PaginatedTypeResponse, object>(url, HttpMethod.Get, null);
        var types = response.Data;
        return types.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Type });
    }

}