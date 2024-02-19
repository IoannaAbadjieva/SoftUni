namespace P05.Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= countOfNumbers; i++)
            {
                int number = i;
                int sumOfDigits = 0;

                while (number != 0)
                {
                    int currentDigit = number % 10;
                    sumOfDigits += currentDigit;
                    number /= 10;
                }

                bool isSpecial = sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11;
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
