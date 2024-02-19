namespace P02.Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumOfDigits = 0;

            while (number != 0)
            {
                int currentDigit = number % 10;
                sumOfDigits += currentDigit;
                number /= 10;
            }

            Console.WriteLine(sumOfDigits);
        }
    }
}
