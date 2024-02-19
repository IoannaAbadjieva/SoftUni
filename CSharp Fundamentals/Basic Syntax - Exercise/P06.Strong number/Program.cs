namespace P06.Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int value = number;

            int sumOfFactorials = 0;

            while (value != 0)
            {
                int currentDigit = value % 10;
                int currDigitFactorial = 1;

                for (int j = 1; j <= currentDigit; j++)
                {
                    currDigitFactorial *= j;
                }

                sumOfFactorials += currDigitFactorial;

                value /= 10;
            }

            if (number == sumOfFactorials)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
