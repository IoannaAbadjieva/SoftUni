namespace P05.Sum_Even_Numbers
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

            for (int index = 0; index < numbers.Length; index++)
            {
                int currentNumber = numbers[index];

                if (currentNumber % 2 == 0)
                {
                    sumOfEvens += currentNumber;
                }
            }

            Console.WriteLine(sumOfEvens);
        }
    }
}
