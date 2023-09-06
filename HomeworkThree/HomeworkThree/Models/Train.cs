namespace HomeworkThree
{
    public class Train : Vehicle
    {
        public int PassengerCapacity { get; set; }

        public Train(string name, int year, float speed, float weight,int passengerCapacity) : base(name, year, speed, weight)
        {
            PassengerCapacity = passengerCapacity;
        }

        public new void Move(float speed) => Console.WriteLine("Train by train");

        public override double GetSpeed()
        {
            return Speed;
        }
    }
}
