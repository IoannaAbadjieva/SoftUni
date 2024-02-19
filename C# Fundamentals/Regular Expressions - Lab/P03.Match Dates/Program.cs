using System.Text.RegularExpressions;

namespace P03.Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>\d{2})([\.\-\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);

            foreach (Match date in matches)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
