namespace P05.Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double account = 0;

            while (input != "NoMoreMoney")
            {
                double num = double.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {num:f2}");
                account += num;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {account:f2}");
        }
    }
}
