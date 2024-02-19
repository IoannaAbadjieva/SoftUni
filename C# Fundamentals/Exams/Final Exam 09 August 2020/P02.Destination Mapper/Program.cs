using System.Text.RegularExpressions;

namespace P02.Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=(?<delimiter>=|\/))[A-Z][A-Za-z]{2,}(?=\k<delimiter>)";
            MatchCollection destinations = Regex.Matches(input, pattern);

            //int travelPoints = 0;

            //foreach (Match destination in destinations)
            //{
            //    travelPoints += destination.Length;
            //}

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {destinations.Sum(x => x.Value.Length)}");
        }
    }
}
