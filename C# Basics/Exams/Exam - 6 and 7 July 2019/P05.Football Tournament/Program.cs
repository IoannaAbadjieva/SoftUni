namespace P05.Football_Tournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            char result;
            int points = 0;
            int winsCount = 0;
            int deucesCount = 0;
            int lostsCount = 0;

            for (int i = 1; i <= n; i++)
            {
                result = char.Parse(Console.ReadLine());
                if (result == 'W')
                {
                    winsCount++;
                    points += 3;
                }
                else if (result == 'D')
                {
                    deucesCount++;
                    points += 1;
                }
                else lostsCount++;
            }
            if (n > 0)
            {
                Console.WriteLine($"{team} has won {points} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {winsCount}");
                Console.WriteLine($"## D: {deucesCount}");
                Console.WriteLine($"## L: {lostsCount}");
                Console.WriteLine($"Win rate: {winsCount * 100.0 / n:f2}%");
            }
            else
            {
                Console.WriteLine($"{team} hasn't played any games during this season.");
            }
        }
    }
}
