namespace HomeworkThree
{
    public class SportCar : Car
    {



        public SportCar(string name, int year, float speed, float weight, bool isRaces) : base(name, year, speed, weight, isRaces)
        {
        }

        public override void IsConfortable(bool IsRaces)
        {
            if (IsRaces)
            {
                Console.WriteLine("Non-comfortable/ but faster then your CPU");
                return;
            }
            Console.WriteLine("comfortable");
        }
        public override void Move(float speed)
        {
            if (speed > 200) Console.WriteLine("YOur car is elusive");
            else Console.WriteLine("Not bad sport car");
        }
    }
}
