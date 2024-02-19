namespace P10.Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int SumOfEvenDigits = GetSumOfEvenDigits(number);
            int SumOfOddDigits = GetSumOfOddDigits(number);

            Console.WriteLine(SumOfEvenDigits * SumOfOddDigits);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                int digit = number % 10;

                if (digit % 2 == 0)
                {
                    sum += digit;
                }
                number /= 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                int digit = number % 10;

                if (digit % 2 != 0)
                {
                    sum += digit;
                }
                number /= 10;
            }

            return sum;
        }
    }
}
