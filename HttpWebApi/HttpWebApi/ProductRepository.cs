
using HttpWebApi.Repositories;

namespace HttpWebApi
{
    public class ProductRepository : IProductRepository
    {
        const string filePath = @"D:\contacts.txt";
        private FileRepository _products;
        public ProductRepository(FileRepository products)
        {
            _products = products;
        }

        public async Task<(Guid, Product)?> GetProductByIdAsync(Guid productId)
        {
            await _products.ReadFromFileAsync(filePath);
            if (_products.productsDictionary.TryGetValue(productId, out var product))
            {
                product.Id = productId;
                return (productId, product);
            }
            return null;
        }
        public async Task<IEnumerable<Product?>> GetAsync()
        {
            await _products.ReadFromFileAsync(filePath);
            return  _products.productsDictionary.Values;    
        }
        public async Task<Product?> PostProductAsync(Product product)
        {

            var productId = Guid.NewGuid();
            product.Id = productId;
            _products.productsDictionary[productId] = product;
            await _products.WriteToFileAsync(filePath);
            return product;
        }
        public async Task<Product?> UpdateAsync(Product product)
        {
            if (_products.productsDictionary.ContainsKey(product.Id))
            {
                _products.productsDictionary[product.Id] = product;
                await _products.WriteToFileAsync(filePath);
                return product;
            }
            return null;
        }
        public async Task<Product?> DeleteAsync(Guid productId)
        {

            if (_products.productsDictionary.TryGetValue(productId, out var product))
            {
                _products.productsDictionary.Remove(productId);
                return product;
            }
            await _products.WriteToFileAsync(filePath);
            return null;
        }
    }
}
