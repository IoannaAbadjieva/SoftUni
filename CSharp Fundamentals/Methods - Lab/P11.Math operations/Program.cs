namespace P11.Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int second = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(first, @operator, second));
        }

        static double Calculate(int firstNumber, string @operator, int secondNumber)
        {
            double result = 0;

            if (@operator == "/")
            {
                result = firstNumber / secondNumber;
            }
            else if (@operator == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (@operator == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (@operator == "+")
            {
                result = firstNumber + secondNumber;
            }

            return result;
        }
    }
}
