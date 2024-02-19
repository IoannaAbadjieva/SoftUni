namespace P05.Movie_Ratings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string movie;
            double rate;
            double maxRate = 0.0;
            double minRate = 11.0;
            string highest = "";
            string lowest = "";

            double average = 0.0;

            for (int i = 1; i <= n; i++)
            {
                movie = Console.ReadLine();
                rate = double.Parse(Console.ReadLine());
                if (rate > maxRate)
                {
                    maxRate = rate;
                    highest = movie;
                }
                if (rate < minRate)
                {
                    minRate = rate;
                    lowest = movie;
                }
                average += rate;
            }
            average /= n;
            Console.WriteLine($"{highest} is with highest rating: {maxRate:f1}");
            Console.WriteLine($"{lowest} is with lowest rating: {minRate:f1}");
            Console.WriteLine($"Average rating: {average:f1}");
        }
    }
}
