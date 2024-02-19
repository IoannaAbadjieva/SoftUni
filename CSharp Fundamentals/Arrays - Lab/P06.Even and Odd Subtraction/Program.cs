namespace P06.Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            int sumOfEvens = 0;
            int sumOfOdds = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                int currentNumber = numbers[index];

                if (currentNumber % 2 == 0)
                {
                    sumOfEvens += currentNumber;
                }
                else
                {
                    sumOfOdds += currentNumber;
                }
            }

            Console.WriteLine(sumOfEvens - sumOfOdds);
        }
    }
}
