using System.Text.RegularExpressions;

namespace P02.Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(#|@)(?<wordOne>[A-Za-z]{3,})\1{2}(?<wordTwo>[A-Za-z]{3,})\1";
            List<string> mirrorWords = new List<string>();
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            GetMirrorWordsPairs(matches, mirrorWords);

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", mirrorWords));
            }
        }

        static void GetMirrorWordsPairs(MatchCollection matches, List<string> mirrorWords)
        {
            foreach (Match pair in matches)
            {
                string wordOne = pair.Groups["wordOne"].Value;
                string wordTwo = pair.Groups["wordTwo"].Value;

                string wordTwoReversed = string.Join("", wordTwo.Reverse());
                if (wordOne.Equals(wordTwoReversed))
                {
                    mirrorWords.Add($"{wordOne} <=> {wordTwo}");
                }
            }
        }
    }
}
