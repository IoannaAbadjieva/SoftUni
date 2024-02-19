namespace P05.Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            double thirdNum = double.Parse(Console.ReadLine());

            PrintMultiplicationSign(firstNum, secondNum, thirdNum);
        }

        static void PrintMultiplicationSign(double num1, double num2, double num3)
        {
            bool condition1 = num1 < 0 && num2 < 0 && num3 > 0;
            bool condition2 = num1 < 0 && num2 > 0 && num3 < 0;
            bool condition3 = num1 > 0 && num2 < 0 && num3 < 0;

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else if (condition1 || condition2 || condition3)
            {
                Console.WriteLine("positive");
            }
            else if (num1 < 0 || num2 < 0 || num3 < 0)
            {
                Console.WriteLine("negative");
            }

            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
