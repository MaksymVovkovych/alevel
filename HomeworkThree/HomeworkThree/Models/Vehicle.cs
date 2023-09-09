namespace HomeworkThree
{
    public class Vehicle : IMoveable, IComparable<Vehicle>
    {
        public string? Name { get; set; }
        public int Year { get; init; }
        public float Speed { get; set; }
        public float Weight { get; init; }

        public Vehicle(string name, int year, float speed, float weight)
        {
            Name = name;
            Year = year;
            Speed = speed;
            Weight = weight;

        }

        public virtual void Move(float speed) => Console.WriteLine($"This transport moves on with {speed}km/h");

        public int CompareTo(Vehicle? other)
        {
            return GetSpeed().CompareTo(other!.GetSpeed());
        }
        public virtual double GetSpeed()
        {
            return 0.0;
        }
    }
}
