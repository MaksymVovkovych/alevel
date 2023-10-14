using HomeworkTwo.Repositories;
using HomeworkTwo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTwo
{
    internal class App
    {
        private readonly ShopService _shopService;
        private readonly ProductServices _productServices;

        public App(ShopService shopService, ProductServices productServices)
        {
            _shopService = shopService;
            _productServices = productServices;
        }

        public void Start()
        {
            Console.WriteLine("Hello, input the command for your tasks.");
            while (true)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Products");
                Console.WriteLine("Shopping Cart");
                Console.WriteLine("Make an order");
                Console.WriteLine("Input a command:");
                var command = Console.ReadLine();
                Console.WriteLine(Environment.NewLine);
                switch (command)
                {
                    case "Products":
                        {
                            _productServices.GetProducts();
                            //я зробив реалізацію додавання продукту до локального сховища ,
                            //але це не є основною задачею тому я просто не використовуватиму це що не засмічувати код
                            break;
                        }
                    case "Shopping Cart":
                        {
                            Console.WriteLine("Input name of product for add to shopping cart");
                            string? name = Console.ReadLine();
                            if(name == null)
                            {
                                break;
                            }
                            _shopService.AddItem(name);
                            Console.WriteLine(Environment.NewLine);
                            _shopService.GetItems();
                            break;
                        }
                    case "Make an order":
                        {
                            _shopService.CreateAnOrder();
                            break;
                        }
                    case "exit":
                        {
                            return;
                        }
                    default: { return; }
                }
            }
        }

    }
}
