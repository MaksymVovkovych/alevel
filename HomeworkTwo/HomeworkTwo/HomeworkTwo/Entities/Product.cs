using System;

public class Product
{
    public Guid Id { get; set; }
    public int Cost { get; set; }
    public required string Label { get; set; }
    public string? Description { get; set; }
}
