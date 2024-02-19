namespace P03.Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemumsCount = int.Parse(Console.ReadLine());
            int rosesCount = int.Parse(Console.ReadLine());
            int tulipsCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char isHoliday = char.Parse(Console.ReadLine());

            double bouquetPrice = 0.0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    bouquetPrice = chrysanthemumsCount * 2.0 + rosesCount * 4.1 + tulipsCount * 2.50;
                    if (season == "Spring" && tulipsCount > 7)
                    {
                        bouquetPrice -= bouquetPrice * 0.05;
                    }
                    break;
                case "Autumn":
                case "Winter":
                    bouquetPrice = chrysanthemumsCount * 3.75 + rosesCount * 4.5 + tulipsCount * 4.15;
                    if (season == "Winter" && rosesCount >= 10)
                    {
                        bouquetPrice -= bouquetPrice * 0.10;
                    }
                    break;

            }

            if (isHoliday == 'Y')
            {
                bouquetPrice *= 1.15;
            }

            if ((chrysanthemumsCount + rosesCount + tulipsCount) > 20)
            {
                bouquetPrice -= bouquetPrice * 0.20;
            }

            bouquetPrice += 2;
            Console.WriteLine("{0:f2}", bouquetPrice);
        }
    }
}
