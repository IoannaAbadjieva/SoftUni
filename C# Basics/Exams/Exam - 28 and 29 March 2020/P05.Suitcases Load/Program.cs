namespace P05.Suitcases_Load
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            double suitcaseVol;
            int counter = 0;
            int loadedCounter = 0;

            string input = Console.ReadLine();
            while (input != "End")
            {
                suitcaseVol = double.Parse(input);
                counter++;
                if (counter % 3 == 0)
                {
                    suitcaseVol += suitcaseVol * 0.10;
                }
                capacity -= suitcaseVol;
                if (capacity < 0)
                {
                    Console.WriteLine("No more space!");
                    break;
                }
                loadedCounter++;

                input = Console.ReadLine();
            }
            if (capacity >= 0)
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
            Console.WriteLine($"Statistic: {loadedCounter} suitcases loaded.");
        }
    }
}
