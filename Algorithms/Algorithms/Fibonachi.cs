namespace Algorithms
{
    public static class Fibonachi
    {
        public static int FibonachiFunc(this int n)
        {
           return n <= 1 ? n : FibonachiFunc(n - 1) + FibonachiFunc(n - 2);
        }
    }
}
