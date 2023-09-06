using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkThree
{
    public class FamilyCar : Car
    {


        public FamilyCar(string name, int year, float speed, float weight, bool isRaces) : base(name, year, speed, weight, isRaces)
        {
        
        }
        public new void IsConfortable(bool IsRaces)
        {
            if(IsRaces) 
            {
                Console.WriteLine("It`s comfortable car");
                return;
                 
            }
            Console.WriteLine("Non-comfortable car");
        }
        public override double GetSpeed()
        {
            return Speed;
        }
    }
}
