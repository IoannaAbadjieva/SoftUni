using System.Text.RegularExpressions;

namespace P02.Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                string emojiPattern = @"(:{2}|\*{2})([A-Z][a-z]{2,})\1";
                string numbersPattern = @"\d";

                string input = Console.ReadLine();

                MatchCollection numbersMatches = Regex.Matches(input, numbersPattern);
                long cooltreshold = numbersMatches
                    .Select(x => int.Parse(x.Value))
                    .Aggregate((x, y) => x * y);

                Console.WriteLine($"Cool threshold: {cooltreshold}");

                MatchCollection emojiMatches = Regex.Matches(input, emojiPattern);
                Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
                foreach (Match emoji in emojiMatches)
                {
                    int coolness = emoji.Groups[2].Value
                         .ToCharArray()
                         .Sum(x => x);

                    if (coolness >= cooltreshold)
                    {
                        Console.WriteLine(emoji.Value);
                    }
                }
            }
        }
    }
}
