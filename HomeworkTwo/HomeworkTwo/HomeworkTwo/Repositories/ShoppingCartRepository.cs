using System.Collections.Generic;

namespace HomeworkTwo.Repositories
{
    public class ShoppingCartRepository
    {

        private readonly List<Product> _shopingCart = new List<Product>();
        private readonly List<Product> _products;
        public ShoppingCartRepository(List<Product> products)
        {
            _products = products;
        }
        public void AddProductToShopingCart(Product product)
        {
            if (_products.Contains(product))
            {
                _shopingCart.Add(product);
            }
            else Console.WriteLine($"this product: {product.Label}is not in the list");
        }

        public void RemoveProductFromShopingCart(Product product) => _shopingCart.Remove(product);
        public void GetProductsFromShopingCart()
        {
            foreach (var product in _shopingCart)
            {
                Console.WriteLine(product.Label);
            }
        }
        public void MakeAOrder()
        {
            if (_shopingCart != null)
            {
                Console.WriteLine($"Your order is ready.#{Guid.NewGuid()}\n with :");
                foreach (var product in _shopingCart)
                {
                    Console.WriteLine(product.Label);
                }
                _shopingCart.Clear();
            }
            else { Console.WriteLine("Your shoping cart is empty"); }
        }



    }
}
