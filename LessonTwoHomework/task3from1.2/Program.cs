void GetDate() => Console.WriteLine(DateTime.Now.ToString("d"));
void GetTime() => Console.WriteLine(DateTime.Now.ToString("t"));
Random random = new Random();
int temperature = random.Next(-10, 35);
void GetTemperature(int temperature) => Console.WriteLine($"{DateTime.Now.ToString()} and temperature is {temperature}`C");


Console.WriteLine("Hello ,input your name and surname");
var name = Console.ReadLine();
var surname = Console.ReadLine();

while (true)
{
    Console.WriteLine(">get-date");
    Console.WriteLine(">get-time");
    Console.WriteLine(">get-temperature");
    Console.WriteLine(">exit");

    Console.WriteLine("Input a choice:");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "get-date":
            {
                GetDate();
                break;
            }
        case "get-time":
            {
                GetTime(); break;
            }
        case "get-temperature":
            {
                GetTemperature(temperature); break;
            }
        case "exit":
            {
                Console.WriteLine($"Bye {name} {surname}"); return;
            }
        default: { Console.WriteLine($"Bye {name} {surname}"); return; }
    }
}