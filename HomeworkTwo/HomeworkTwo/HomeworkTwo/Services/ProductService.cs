using System;
using System.Reflection.Metadata.Ecma335;

public class ProductServices
{
	private readonly ProductRepository _productRepository;
	public ProductServices(ProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	public void GetProducts() => _productRepository.GetProducts();
	
    public Product? GetProductById(Guid Id) 
	{
		var product = _productRepository.GetProductById(Id);
		if(product == null)
		{
			Console.WriteLine($"Product by Id {Id} is gone.");
			return null;
		}
		return product;

	}
	public string AddProduct(int cost,string label, string descript) 
	{
		var product = new Product {Id = Guid.NewGuid(),Cost = cost, Label = label, Description = descript };
		_productRepository.AddProduct(product);
		Console.WriteLine($"{product.Label} was added to products");
		return product.Id.ToString();
	}

}
