
public class ProductRepository
{
    private readonly List<Product> _products;
    public ProductRepository(List<Product> products)
    {
        _products = products;
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public void GetProducts()
    {
        foreach (var product in _products)
        {
            Console.WriteLine(product.Label);
        }
    }
    public Product? GetProductById(Guid Id)
    {
        var product = _products.FirstOrDefault(x => x.Id == Id);
        if (product != null)
        {
            return product;
        }
        return null;
    }
    public Product? GetProductByName(string name)
    {
        var product = _products.FirstOrDefault(x => x.Label == name);
        if (product != null)
        {
            return product;
        }
        return null;
    }

}
