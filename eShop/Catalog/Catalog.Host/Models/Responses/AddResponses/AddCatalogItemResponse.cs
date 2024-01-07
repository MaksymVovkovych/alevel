namespace Catalog.Host.Services.Interfaces.AddResponses;

public class AddCatalogItemResponse<T>
{
    public T Id { get; set; } = default!;
}