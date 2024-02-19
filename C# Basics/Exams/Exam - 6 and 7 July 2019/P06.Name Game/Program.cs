namespace P06.Name_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string player = Console.ReadLine();
            int num;
            int points;
            int maxPoints = 0;
            string winner = "";

            while (player != "Stop")
            {
                points = 0;
                for (int i = 0; i < player.Length; i++)
                {
                    num = int.Parse(Console.ReadLine());
                    if (num == player[i])
                    {
                        points += 10;
                    }
                    else
                    {
                        points += 2;
                    }
                }
                if (points >= maxPoints)
                {
                    maxPoints = points;
                    winner = player;
                }
                player = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {winner} with {maxPoints} points!");
        }
    }
}
