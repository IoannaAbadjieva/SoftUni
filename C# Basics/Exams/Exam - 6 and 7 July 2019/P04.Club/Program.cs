namespace P04.Club
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double incomeNeeded = double.Parse(Console.ReadLine());
            double price = 0.0;
            double income = 0.0;

            string input = Console.ReadLine();
            while (input != "Party!")
            {
                int count = int.Parse(Console.ReadLine());
                price = input.Length * count;
                if (price % 2 != 0)
                {
                    price -= price * 0.25;
                }
                income += price;
                if (income >= incomeNeeded)
                {
                    Console.WriteLine("Target acquired.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Party!")
            {
                Console.WriteLine($"We need {incomeNeeded - income:f2} leva more.");
            }
            Console.WriteLine($"Club income - {income:f2} leva.");
        }
    }
}
