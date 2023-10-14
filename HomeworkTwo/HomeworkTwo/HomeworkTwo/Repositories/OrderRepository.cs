
////так би виглядало  оформлення замовлення реалізувавши через окремий від кошика репозиторій ,
///але не вийшло через проблему з передачею в конструктор ліста _shoppingCart,тому зробив в тому ж репозиторії що й кошик ,
///маю надію що це нічого страшного 

//namespace HomeworkTwo.Repositories
//{
//    public class OrderRepository
//    {
//        private readonly List<Product> _shopingCart;
//        public OrderRepository(List<Product> shopingCart)
//        {
//            _shopingCart = shopingCart;
//        }
//        public void MakeAOrder()
//        {
//            if (_shopingCart != null)
//            {
//                Console.WriteLine($"Your order is ready.#{Guid.NewGuid}\n with :");
//                foreach (var product in _shopingCart)
//                {
//                    Console.WriteLine(product.Label);
//                }
//                _shopingCart.Clear();
//            }
//            else { Console.WriteLine("Your shoping cart is empty"); }
//        }


//    }
//}

