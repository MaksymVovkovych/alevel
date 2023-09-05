using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkThree
{
    public class Car : Vehicle 
    {
        public bool IsRaces { get; set; }
        public Car(string name, int year, float speed, float weight,bool isRaces) :base(name,year,speed,weight)
        {
            IsRaces = isRaces;
        }
        public virtual void IsConfortable(bool IsRaces)
        {
            if (!IsRaces)
            {
                Console.WriteLine("This car not for races ,she is for flex drive");
            }
            else Console.WriteLine("Race - CAR!");
            
            
        }

        public override void Move(float speed)
        {
            Console.WriteLine($"This car has can accelerate to {speed},not bad.");
        }



    }
}
