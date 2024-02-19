namespace P04.Easter_Eggs_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int player1 = int.Parse(Console.ReadLine());
            int player2 = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();


            while (input != "End of battle")
            {
                if (input == "one")
                {
                    player2 -= 1;
                    if (player2 == 0)
                    {
                        Console.WriteLine($"Player two is out of eggs. Player one has {player1} eggs left.");
                        break;
                    }
                }
                else
                {
                    player1 -= 1;
                    if (player1 == 0)
                    {
                        Console.WriteLine($"Player one is out of eggs. Player two has {player2} eggs left.");
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            if (input == "End of battle")
            {
                Console.WriteLine($"Player one has {player1} eggs left.");
                Console.WriteLine($"Player two has {player2} eggs left.");
            }

        }
    }
}
