var N = int.Parse(Console.ReadLine());
var lowestNumber  = int.Parse(Console.ReadLine());
var biggestNumber = int.Parse(Console.ReadLine());

int[,] array = new int[N,N];
int evenNumbers = 0;
int oddNumbers = 0;
Random random = new Random();
for(int i = 0; i < N; i++)
{
    for(int j = 0; j < N; j++)
    {
        array[i,j] = random.Next(lowestNumber, biggestNumber);
        if (array[i,j] % 2 == 0)
        {
            evenNumbers++;
        }
        else
        {
            oddNumbers++;
        }
    }
}
for (int i = 0; i < N; i++)
{

    for (int j = 0; j < N; j++)
    {
        Console.Write(array[i, j] + "\t");
    }
    Console.WriteLine("\n");
}
int min = array[0, 0];
int max = array[0, 0];

void MinMax(int[,] array , out int Min , out int Max)
{
    Min = array[0, 0];
    Max = array[0, 0];

    for ( int i = 0; i < N; i++)
    {
        for( int j = 0; j < N; j++)
        {
            if (array[i,j] < Min)
            {
                Min = array[i,j];
            }
            if(array[i, j] > Max)
            {
                Max = array[i,j];
            }
        }
    }
}
MinMax(array, out min, out max);
Console.WriteLine($"Max num: {max}");
Console.WriteLine($"Min num: {min}");