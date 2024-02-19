namespace P03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                string command = Console.ReadLine();
                double num1 = double.Parse(Console.ReadLine());
                double num2 = double.Parse(Console.ReadLine());

                if (command == "add")
                {
                    Add(num1, num2);
                }
                else if (command == "multiply")
                {
                    Multiply(num1, num2);
                }
                else if (command == "subtract")
                {
                    Subtract(num1, num2);
                }
                else if (command == "divide")
                {
                    Divide(num1, num2);
                }
            }

            static void Add(double number1, double number2)
            {
                Console.WriteLine(number1 + number2);
            }

            static void Multiply(double number1, double number2)
            {
                Console.WriteLine(number1 * number2);
            }

            static void Subtract(double number1, double number2)
            {
                Console.WriteLine(number1 - number2);
            }

            static void Divide(double number1, double number2)
            {
                Console.WriteLine(number1 / number2);
            }
        }
    }
}
