namespace P04.Fishing_Boat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermenCount = int.Parse(Console.ReadLine());

            double rent = 0.0;

            if (season == "Spring")
            {
                rent = 3000;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                rent = 4200;
            }
            else
            {
                rent = 2600;
            }

            if (fishermenCount <= 6)
            {
                rent -= rent * 0.1;
            }
            else if (fishermenCount <= 11)
            {
                rent -= rent * 0.15;
            }
            else
            {
                rent -= rent * 0.25;
            }

            if (fishermenCount % 2 == 0 && season != "Autumn")
            {
                rent -= rent * 0.05;
            }

            double difference = budget - rent;
            if (difference >= 0)
            {
                Console.WriteLine($"Yes! You have {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(difference):f2} leva.");
            }
        }
    }
}
