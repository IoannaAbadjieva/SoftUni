namespace P02.Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int divisibleBy = 0;

            if (number % 10 == 0)
            {
                divisibleBy = 10;
            }
            else if (number % 7 == 0)
            {
                divisibleBy = 7;
            }
            else if (number % 6 == 0)
            {
                divisibleBy = 6;
            }
            else if (number % 3 == 0)
            {
                divisibleBy = 3;
            }
            else if (number % 2 == 0)
            {
                divisibleBy = 2;
            }

            if (divisibleBy != 0)
            {
                Console.WriteLine($"The number is divisible by {divisibleBy}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
