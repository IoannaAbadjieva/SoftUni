namespace P06.Tournament_of_Christmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string sport;
            string result;
            int wins;
            int losses;
            double moneyRaised;
            int winsTotal = 0;
            double moneyTotal = 0.0;

            for (int i = 1; i <= n; i++)
            {
                wins = 0;
                losses = 0;
                moneyRaised = 0.0;

                sport = Console.ReadLine();
                while (sport != "Finish")
                {
                    result = Console.ReadLine();
                    if (result == "win")
                    {
                        wins++;
                        moneyRaised += 20;
                    }
                    else
                    {
                        losses++;
                    }
                    sport = Console.ReadLine();
                }
                if (wins > losses)
                {
                    moneyRaised += moneyRaised * 0.10;
                    winsTotal++;
                }
                moneyTotal += moneyRaised;
            }
            if (winsTotal > n - winsTotal)
            {
                moneyTotal += moneyTotal * 0.20;
                Console.Write("You won the tournament! ");
            }
            else
            {
                Console.Write("You lost the tournament! ");
            }
            Console.WriteLine($"Total raised money: {moneyTotal:f2}");
        }
    }
}
