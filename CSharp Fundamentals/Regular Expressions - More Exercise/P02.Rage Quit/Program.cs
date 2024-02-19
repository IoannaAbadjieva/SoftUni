using System.Text.RegularExpressions;
using System.Text;

namespace P02.Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine().ToUpper();
            string pattern = @"([^0-9]+)([0-9]+)";
            MatchCollection matches = Regex.Matches(input, pattern);
            int uniqueSymbolsCount = GetUniqueSymbolsCount(matches);
            string rageMessage = GetRageMessage(matches);

            Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");
            Console.WriteLine(rageMessage);
        }

        static int GetUniqueSymbolsCount(MatchCollection matches)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                int repeatCounts = int.Parse(match.Groups[2].Value);
                if (repeatCounts != 0)
                {
                    sb.Append(match.Groups[1].Value);
                }
            }

            List<char> chars = new List<char>();
            string symbols = sb.ToString();

            foreach (char ch in symbols)
            {
                if (!chars.Contains(ch))
                {
                    chars.Add(ch);
                }
            }

            return chars.Count;
        }

        static string GetRageMessage(MatchCollection matches)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                string stringToRepeat = match.Groups[1].Value;
                int repeatsCount = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < repeatsCount; i++)
                {
                    sb.Append(stringToRepeat);
                }
            }

            return sb.ToString();
        }
    }
}
