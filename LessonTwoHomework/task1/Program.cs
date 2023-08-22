
Console.WriteLine("Input count numbers in array:");
var N = int.Parse(Console.ReadLine());
Console.WriteLine("Input lowest and biggest numbers in array:");
var low = int.Parse(Console.ReadLine());
var big = int.Parse(Console.ReadLine());
int[] CreateArray(int N,int low , int big)
{
    Random random = new Random();
    int[] randomNumbers = new int[N];

    for (int i = 0; i < N; i++)
    {
        randomNumbers[i] = random.Next(low, big);
    }
    return randomNumbers;
}

var Numbers = CreateArray(N,low,big);

foreach (int i in Numbers)
{
    Console.WriteLine(i);
}
var counter = 0;
foreach (int currentNumber in Numbers)
{
    if (currentNumber <= 100 && currentNumber >= -100) counter++;
    else continue;
}
Console.WriteLine(counter);