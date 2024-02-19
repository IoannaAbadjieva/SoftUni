using System.Text.RegularExpressions;

namespace P02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] racersNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> race = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                string name = GetRacerName(input);
                int distance = GetDistance(input);

                if (!racersNames.Contains(name))
                {
                    continue;
                }

                if (!race.ContainsKey(name))
                {
                    race[name] = distance;
                }
                else
                {
                    race[name] += distance;
                }
            }
            PrintBestRacers(race);
        }

        static string GetRacerName(string input)
        {
            string namePattern = @"[A-Za-z]{1}";
            MatchCollection nameMatches = Regex.Matches(input, namePattern);

            char[] nameMatch = nameMatches
                        .Select(x => char.Parse(x.Value))
                        .ToArray();
            string name = new string(nameMatch);
            return name;
        }

        static int GetDistance(string input)
        {
            string distancePattern = @"[0-9]{1}";
            MatchCollection distanceMatches = Regex.Matches(input, distancePattern);

            int distance = distanceMatches
                       .Select(x => int.Parse(x.Value))
                       .Aggregate((a, b) => a + b);

            return distance;
        }

        static void PrintBestRacers(Dictionary<string, int> race)
        {
            string[] places = { "1st place", "2nd place", "3rd place" };

            List<string> sortedRacers = race
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .ToList();

            for (int i = 0; i < 3; i++)
            {
                if (i < sortedRacers.Count)
                {
                    Console.WriteLine($"{places[i]}: {sortedRacers[i]}");
                }
            }
        }
    }
}
