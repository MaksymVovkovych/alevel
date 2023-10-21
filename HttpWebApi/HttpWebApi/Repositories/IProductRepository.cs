
namespace HttpWebApi.Repositories
{
    public interface IProductRepository 
    {
        public  Task<IEnumerable<Product>> GetAsync();
        public  Task<(Guid, Product)?> GetProductByIdAsync(Guid productId);
        public  Task<Product?> PostProductAsync(Product product);
        public  Task<Product?> UpdateAsync(Product product);
        public  Task<Product?> DeleteAsync(Guid productId);
    }
}
