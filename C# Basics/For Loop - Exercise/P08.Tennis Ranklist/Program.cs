namespace P08.Tennis_Ranklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int endingPoints = startingPoints;
            int wins = 0;

            for (int i = 1; i <= n; i++)
            {
                string round = Console.ReadLine();

                if (round == "W")
                {
                    endingPoints += 2000;
                    wins++;
                }
                else if (round == "F")
                {
                    endingPoints += 1200;
                }
                else
                {
                    endingPoints += 720;
                }
            }

            Console.WriteLine($"Final points: {endingPoints}");
            Console.WriteLine($"Average points: {(endingPoints - startingPoints) / n}");
            Console.WriteLine($"{wins * 100.0 / n:f2}%");
        }
    }
}
