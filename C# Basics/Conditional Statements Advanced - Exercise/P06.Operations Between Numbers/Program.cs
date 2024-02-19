namespace P06.Operations_Between_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double result = 0;

            //събиране, изваждане и умножение на конзолата трябва да се отпечатат резултата и дали той е четен или нечетен
            //При обикновеното деление – резултата
            //При модулното деление – остатъка. 
            if (operation == '+' || operation == '-' || operation == '*')
            {
                string oddOrEven = "odd";

                if (operation == '+')
                {
                    result = num1 + num2;
                }
                else if (operation == '-')
                {
                    result = num1 - num2;
                }
                else
                {
                    result = num2 * num1;
                }

                if (result % 2 == 0)
                {
                    oddOrEven = "even";
                }
                Console.WriteLine($"{num1} {operation} {num2} = {result} - {oddOrEven}");
            }
            else
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    if (operation == '/')
                    {
                        result = (double)num1 / num2;
                        Console.WriteLine($"{num1} {operation} {num2} = {result:f2}");
                    }
                    else
                    {
                        result = num1 % num2;
                        Console.WriteLine($"{num1} {operation} {num2} = {result}");
                    }
                }

            }
        }
    }
}
