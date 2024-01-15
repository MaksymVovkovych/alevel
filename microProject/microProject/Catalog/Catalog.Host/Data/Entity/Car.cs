using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Data.Entity;

public class Car
{
    public int Id { get; set; }
    [Range(1980, 2024)]
    public int Year { get; set; }
    public string Color { get; set; } = null!;
    public int BrandId { get; set; }
    public Brand Brand { get; set; }

}