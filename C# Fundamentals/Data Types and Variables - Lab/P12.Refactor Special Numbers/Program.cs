namespace P12.Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int number = 1; number <= count; number++)
            {
                int currentNumber = number;
                int sumOfDigits = 0;

                while (currentNumber > 0)
                {
                    int currentDigit = currentNumber % 10;
                    sumOfDigits += currentDigit;
                    currentNumber /= 10;
                }

                bool isSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine("{0} -> {1}", number, isSpecial);
            }
        }
    }
}
