using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models.Enums;
using MVC.Models.Requests;
using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type);
    Task<IEnumerable<SelectListItem>> GetBrands();
    
    Task<IEnumerable<SelectListItem>> GetTypes();
}