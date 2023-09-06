

namespace HomeworkThree { 


    class Program
    {
        static void Main(string[] args) 
        {
            //for sort i chosed List
            List<Vehicle> list = new List<Vehicle>
            {
                new Car("Lanos",1999,116.5F,3.5F,false),
                new Airplane("Boeng-737",2017,160,70.8F,10000),
                new Train("Ykrzaliznutsya",1995,60,42,600),
                new SportCar("Buggati", 2014,300,2.2F,true),
                new FamilyCar("BMW",1998,160,3.5F,false)
            };
            //before sort with implemented method CompareTo from IComporable
            foreach (var vehicle in list)
            {
                Console.WriteLine(vehicle.Name);
            }
            list.Sort();
            //after sort with implemented method CompareTo from IComporable
            foreach (var vehicle in list)
            {
                Console.WriteLine(vehicle.Name);
            }

            //for Search i chosed Dictionary
            Dictionary<string,Vehicle> dict = new Dictionary<string, Vehicle>
            {
                {"Lanos" , new Car("Lanos",1999,116.5F,3.5F,false)},
                { "Boeng-737" , new Airplane("Boeng-737",2017,160,70.8F,10000) },
                { "Ykrzaliznutsya" , new Train("Ykrzaliznutsya",1995,60,42,600) },
                { "Buggati",  new SportCar("Buggati", 2014,300,2.2F,true) },
                { "BMW", new FamilyCar("BMW",1998,160,3.5F,false) }

            };
            SearchName.Search(dict);


            //example using new 
            var f = new FamilyCar("Foo",1984,270,3000,false);
            f.IsConfortable(false);


        
        
        
        }
    }
}