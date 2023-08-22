static void BubbleSort(int[] array)
{
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (array[j] < array[j + 1])
            {
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }
}
int[] CreateArray(int N)
{
    Random random = new Random();
    int[] randomNumbers = new int[N];

    for (int i = 0; i < N; i++)
    {
        randomNumbers[i] = random.Next(-1000, 1000);
    }
    return randomNumbers;
}

var N = 20;
var Numbers = CreateArray(N);

int[] result = new int[20];
for(int currentNumber = 0; currentNumber < result.Length; currentNumber++)
{
    if (Numbers[currentNumber] <= 888) result[currentNumber] = Numbers[currentNumber];
}
foreach (int i in Numbers)
{
    Console.WriteLine(i);
}
Console.WriteLine(Environment.NewLine);
foreach (int i in result)
{
    Console.WriteLine(i);
}

BubbleSort(result);

Console.WriteLine(Environment.NewLine);
foreach (int i in result)
{
    Console.WriteLine(i);
}