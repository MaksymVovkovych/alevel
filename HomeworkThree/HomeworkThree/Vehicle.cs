using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeworkThree
{
    public class Vehicle : IMoveable
    {
        public  string? Name { get; set; }
        public int Year { get; init; }
        public  float speed { get; init; }
        public float Weight { get; init; }

        public Vehicle(string name,int year,float speed ,float weight)
        {

            this.Year = year;
            this.speed = speed;
            Weight = weight;

        }

        public virtual void Move(float speed) => Console.WriteLine($"This transport moves on with {speed}km/h");
        
    }
}
