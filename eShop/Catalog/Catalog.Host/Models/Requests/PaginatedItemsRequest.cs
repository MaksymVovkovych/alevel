namespace Catalog.Host.Services.Interfaces;

public class PaginatedItemsRequest
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public List<Guid>? BrandIds { get; set; }
    public List<Guid>? TypeIds { get; set; }
}