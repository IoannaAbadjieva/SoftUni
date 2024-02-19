namespace P01.Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int input = int.Parse(Console.ReadLine());
                PrintResult(input);
            }
            else if (type == "real")
            {
                double input = double.Parse(Console.ReadLine());
                PrintResult(input);
            }
            else if (type == "string")
            {
                string input = Console.ReadLine();
                PrintResult(input);
            }
        }

        static void PrintResult(int input)
        {
            Console.WriteLine(2 * input);
        }

        static void PrintResult(double input)
        {
            Console.WriteLine($"{1.5 * input:f2}");
        }

        static void PrintResult(string input)
        {
            Console.WriteLine($"${input}$");
        }

    }
}
