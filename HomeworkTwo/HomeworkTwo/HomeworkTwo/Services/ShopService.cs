
using HomeworkTwo.Repositories;

namespace HomeworkTwo.Services
{
    public class ShopService
    {

        private readonly ShoppingCartRepository _shoppingCartRepository;
        private readonly ProductRepository _productRepository;
        public ShopService(
            ShoppingCartRepository shoppingCartRepository,
            ProductRepository productRepository
            ) 
        { 

            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public void GetItems()
        {
            _shoppingCartRepository.GetProductsFromShopingCart();
        }

        public void AddItem(string name)
        {
            var product = _productRepository.GetProductByName(name);
            if ( product != null )
            {
                _shoppingCartRepository.AddProductToShopingCart(product); 
            } 
        }

        public void CreateAnOrder()
        {
            Console.WriteLine("Your order contains :");
            _shoppingCartRepository.GetProductsFromShopingCart();
            Console.WriteLine("Are you sure?");
            int.TryParse(Console.ReadLine(),out int num);
            if (num == 1)
            {
                _shoppingCartRepository.MakeAOrder();
            }
            else return;
        }
        public string? DeleteItem(string name)
        {
            var product = _productRepository.GetProductByName(name);
            if (product != null)
            {
                _shoppingCartRepository.RemoveProductFromShopingCart(product);
                return product.Label.ToString();
            }
            return null;
        }

    }
}
