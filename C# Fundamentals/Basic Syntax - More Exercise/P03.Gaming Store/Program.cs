namespace P03.Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            
            double price = 0.0;
            double money = balance;
            string game = Console.ReadLine();
            while (game != "Game Time")
            {
                if (game == "OutFall 4" || game == "RoverWatch Origins Edition") price = 39.99;
                else if (game == "CS: OG") price = 15.99;
                else if (game == "Zplinter Zell") price = 19.99;
                else if (game == "Honored 2") price = 59.99;
                else if (game == "RoverWatch") price = 29.99;
                else
                {
                    Console.WriteLine("Not Found");
                    game = Console.ReadLine();
                    continue;
                }

                if (balance >= price)
                {
                    balance -= price;
                    Console.WriteLine($"Bought {game}");
                    if (balance == 0)
                    {
                        Console.WriteLine("Out of money!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }
                game = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${money - balance:f2}. Remaining: ${balance:f2}");
        }
    }
}
