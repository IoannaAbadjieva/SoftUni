namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] words = File.ReadAllText(wordsFilePath).ToLower().Split();
            string text = File.ReadAllText(textFilePath).ToLower();

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();


            foreach (string word in words)
            {
                string pattern = $"\\b{word}\\b";
                MatchCollection matches = Regex.Matches(text, pattern);
                wordCounts[word] = matches.Count();
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var kvp in wordCounts.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
