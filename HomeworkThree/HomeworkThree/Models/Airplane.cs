namespace HomeworkThree
{
    public class Airplane : Vehicle
    {
        public int FlightHeight { get; set; }

        public Airplane(string name, int year, float speed, float weight, int flightHeight):base(name,year,speed,weight)
        {
            FlightHeight = flightHeight;
        }

        public override void Move(float speed)
        {
            Console.WriteLine($"Your Airplane moves on with speed : {speed} and flies at heigst {FlightHeight}");
        }
        public override double GetSpeed()
        {
            return Speed;
        }
    }
}
