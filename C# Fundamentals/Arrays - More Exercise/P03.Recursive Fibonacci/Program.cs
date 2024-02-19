namespace P03.Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            numbers = new long[n + 1];

            Console.WriteLine(Fibonacci(n));
        }

        static long[] numbers;

        static long Fibonacci(int n)
        {
            if (numbers[n] != 0)
            {
                return numbers[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            long result = Fibonacci(n - 1) + Fibonacci(n - 2);

            numbers[n] = result;

            return result;
        }
    }
}
