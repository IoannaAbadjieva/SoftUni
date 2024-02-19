using System.Text.RegularExpressions;

namespace P03.Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] parts = Console.ReadLine()
               .Split('|', StringSplitOptions.RemoveEmptyEntries);

            string capitalLettersPattern = @"([#$%&*])([A-Z]+)\1";
            string capitalLetters = Regex.Match(parts[0], capitalLettersPattern).Groups[2].Value;

            foreach (char ch in capitalLetters)
            {
                string wordsLenghtPattern = $@"{(int)ch}:([0-9]{{2}})";
                Match wordLenght = Regex.Match(parts[1], wordsLenghtPattern);

                if (wordLenght.Success)
                {
                    int wordlenght = int.Parse(wordLenght.Groups[1].Value);
                    string wordPattern = $@"(?<=\s|^){ch}[\S]{{{wordlenght}}}(?=\s|$)";
                    Match wordMatch = Regex.Match(parts[2], wordPattern);

                    if (wordMatch.Success)
                    {
                        Console.WriteLine(wordMatch.Value);
                    }
                }
            }
        }
    }
}
