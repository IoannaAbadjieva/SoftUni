namespace P08.Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double result = Factorial(num1) / Factorial(num2);
            Console.WriteLine($"{result:f2}");
        }

        static double Factorial(int number)
        {
            double result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
