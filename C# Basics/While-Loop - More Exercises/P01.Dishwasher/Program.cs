namespace P01.Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int detergentExtant = n * 750;
            int detergentNeeded = 0;
            int count;
            int daysCounter = 0;
            int dishesCounter = 0;
            int potsCounter = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {
                count = int.Parse(input);
                daysCounter++;

                if (daysCounter % 3 == 0)
                {
                    detergentNeeded += count * 15;
                    potsCounter += count;
                }
                else
                {
                    detergentNeeded += count * 5;
                    dishesCounter += count;
                }

                if (detergentNeeded > detergentExtant)
                {
                    Console.WriteLine($"Not enough detergent, {detergentNeeded - detergentExtant} ml. more necessary!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (detergentExtant >= detergentNeeded)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{dishesCounter} dishes and {potsCounter} pots were washed.");
                Console.WriteLine($"Leftover detergent {detergentExtant - detergentNeeded} ml.");
            }
        }
    }
}
