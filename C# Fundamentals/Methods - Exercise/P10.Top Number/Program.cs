namespace P10.Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int divisibleBy = 8;

            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                if (ValidateTopNumber(i, divisibleBy))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool ValidateTopNumber(int number, int disibleBy)
        {
            bool isTopNumber = true;

            if (!ValidateSumOFDigitsDivByNum(number, disibleBy))
            {
                isTopNumber = false;
            }

            if (!ValidateHoldingOddDigit(number))
            {
                isTopNumber = false;
            }

            return isTopNumber;
        }

        static bool ValidateSumOFDigitsDivByNum(int number, int divisibleBy)
        {
            int sumOfDigits = 0;

            while (number != 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }

            return sumOfDigits % divisibleBy == 0;
        }

        static bool ValidateHoldingOddDigit(int number)
        {

            while (number != 0)
            {
                if ((number % 10) % 2 != 0)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
