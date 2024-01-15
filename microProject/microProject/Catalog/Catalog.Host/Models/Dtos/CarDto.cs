using Catalog.Host.Data.Entity;

namespace Catalog.Host.Mapping;

public class CarDto
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Color { get; set; } = null!;
    public BrandDto Brand { get; set; }
}