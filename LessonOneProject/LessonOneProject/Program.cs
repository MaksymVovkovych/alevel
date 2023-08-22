
Console.WriteLine("Hello.Input 2 numbers .");
var firstNumber = int.Parse(Console.ReadLine());
var secondNumber = int.Parse(Console.ReadLine());
Console.WriteLine("and chose the act ");
char act = Console.ReadKey().KeyChar;
switch (act)
{
    case '+':
        var resultAdd = CalculateLibrary.Add.ADD(firstNumber, secondNumber);
        Console.WriteLine($"Your result: {resultAdd}");
        break;
    case '-':
        var resultSub = CalculateLibrary.Sub.SUB(firstNumber, secondNumber);
        Console.WriteLine($"Your result: {resultSub}");
        break;
    case '*':
        var resultMult = CalculateLibrary.Multiply.MULTIPLY(firstNumber, secondNumber);
        Console.WriteLine($"Your result: {resultMult}");
        break;
    case '/':
        var resultDiv = CalculateLibrary.Divide.DIVIDE(firstNumber, secondNumber);
        Console.WriteLine($"Your result: {resultDiv}");
        break;
}