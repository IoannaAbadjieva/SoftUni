namespace P05.Best_Player
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string player = Console.ReadLine();
            int goals;
            int maxGoals = 0;
            string bestPlayer = "";

            while (player != "END")
            {
                goals = int.Parse(Console.ReadLine());
                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    bestPlayer = player;
                }
                if (goals >= 10)
                {
                    break;
                }
                player = Console.ReadLine();
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (maxGoals >= 3)
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}
