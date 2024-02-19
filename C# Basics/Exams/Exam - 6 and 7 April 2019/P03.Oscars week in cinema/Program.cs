namespace P03.Oscars_week_in_cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string hallType = Console.ReadLine();
            int ticketsCount = int.Parse(Console.ReadLine());
            double income = 0.0;

            switch (hallType)
            {
                case "normal":
                    if (movie == "A Star Is Born") income = 7.50;
                    else if (movie == "Bohemian Rhapsody") income = 7.35;
                    else if (movie == "Green Book") income = 8.15;
                    else income = 8.75;
                    break;

                case "luxury":
                    if (movie == "A Star Is Born") income = 10.50;
                    else if (movie == "Bohemian Rhapsody") income = 9.45;
                    else if (movie == "Green Book") income = 10.25;
                    else income = 11.55;
                    break;

                default:
                    if (movie == "A Star Is Born") income = 13.50;
                    else if (movie == "Bohemian Rhapsody") income = 12.75;
                    else if (movie == "Green Book") income = 13.25;
                    else income = 13.95;
                    break;
            }
            income *= ticketsCount;
            Console.WriteLine($"{movie} -> {income:f2} lv.");
        }
    }
}
