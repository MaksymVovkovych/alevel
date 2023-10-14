using HomeworkTwo.Services;
using HomeworkTwo.Repositories;
using HomeworkTwo;

List<Product> initialProducts = new List<Product>
        {
            new Product{Id = Guid.NewGuid(),Cost = 25,Label = "apple",Description = "tropical1" },
            new Product{Id = Guid.NewGuid(),Cost = 16 ,Label = "pineapple",Description = "tropical2"},
            new Product{Id = Guid.NewGuid(),Cost = 49 ,Label = "bananna",Description = "tropical3"},
            new Product{Id = Guid.NewGuid(),Cost = 100 ,Label = "peach",Description = "tropical4" },
            new Product{Id = Guid.NewGuid(),Cost =45  ,Label = "cherry",Description = "tropical5"},
            new Product{Id = Guid.NewGuid(),Cost = 888 ,Label = "avokado",Description = "tropical6"},
            new Product{Id = Guid.NewGuid(),Cost =6  ,Label = "mango",Description = "tropical7"},
            new Product{Id = Guid.NewGuid(),Cost = 78 ,Label = "abrykos",Description = "tropical8"},
            new Product{Id = Guid.NewGuid(),Cost =6  ,Label = "grape",Description = "tropical9"},
            new Product{Id = Guid.NewGuid(),Cost = 73 ,Label = "orange",Description = "tropical10"},

        };

var application = new App(
    new ShopService(new ShoppingCartRepository(initialProducts),new ProductRepository(initialProducts)),
    new ProductServices(new ProductRepository(initialProducts)));

application.Start();






