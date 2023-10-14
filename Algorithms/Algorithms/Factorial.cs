namespace Algorithms
{
    public static class Factorial
    {
        public static int FactorialFunc(this int value)
        {
            return value == 0 ? 0 :
                   value == 1 ? 1 :
                   value * FactorialFunc(value - 1);
        }
    }
}
